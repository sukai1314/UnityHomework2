using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class movecontrol : MonoBehaviour
{
    public float speed =5f;
    public float rotationSpeed =15f;
    public Transform cameraTransform;

    //剛體
    private Rigidbody rb;
    public float jumpForce = 5f;

    //射線偵測離地
    public float rayDistance = 0.1f;

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

        //動畫
        anim=GetComponent<Animator>();
        if(cameraTransform==null&&Camera.main!=null)
        {
            cameraTransform=Camera.main.transform;
        }
        rb = gameObject.GetComponent<Rigidbody>();
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
        
        if (Input.GetKeyDown(KeyCode.Space)&& RayGround())
        {

            //Vector3 fallsqeed = Physics.gravity;
            //float jumpHight = Mathf.Sqrt(2f*-fallsqeed.y *2f);
            //transform.position += new Vector3(0f, jumpHight, 0f)*Time.deltaTime;

            //用rigbody內建向上的力
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }
    public bool RayGround() 
    {
        Vector3 rayOrigin = transform.position;
        RaycastHit hit;

        bool isGrounded = Physics.Raycast(rayOrigin, Vector3.down, out hit, rayDistance);
        Debug.Log($"{hit.collider.gameObject.name}");
        return isGrounded;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * rayDistance);
    }
}
