using System;
using UnityEngine;

public class movecontrol : MonoBehaviour
{
    public float speed =5f;
    public float rotationSpeed =15f;
    public Transform cameraTransform;

    private Animator anim;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 fallSpeed = Physics.gravity;

        float jumpHight = 1/2*fallSpeed.y*Time.deltaTime*Time.deltaTime-2;

        //°Êµe
        anim=GetComponent<Animator>();
        if(cameraTransform==null&&Camera.main!=null)
        {
            cameraTransform=Camera.main.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {

        MoveControl();

    }
    public void MoveControl()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 inputDir=new Vector3(x,0f,z);

        if (inputDir.magnitude >= 0.1f)
        {
            Vector3 camFor = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camFor.y = 0f;
            camRight.y = 0f;
            camFor.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camFor * z + camRight * x;

            transform.position += moveDir * speed * Time.deltaTime;

            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

            anim.SetBool("walk", true);
        }
        else { anim.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 fallsqeed = Physics.gravity;
            float jumpHight = Mathf.Sqrt(2f*-fallsqeed.y *2f);
            transform.position += new Vector3(0f, jumpHight, 0f) * Time.deltaTime;
        }
    }
}
