using Unity.Mathematics;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    //目標
    public Transform targetObj;
    public float distance = 2f;
    public float rotationSpeed = 5f;

    private float currentX = 0f;
    private float currentY = 0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    GameObject target = GameObject.Find("target");
    if (target != null) 
        { 
        targetObj = target.transform;
        }
        else
        {
            Debug.Log("找不到物件");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
             if (targetObj != null)
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

            currentY=Mathf.Clamp(currentY,yMinLimit,yMaxLimit);

            Quaternion rotation=Quaternion.Euler(0,currentX,0)* Quaternion.Euler(currentY,0 , 0);
            Vector3 negDistance = new Vector3(0f, 0f, -distance);
            Vector3 position = rotation * negDistance + targetObj.position;
            transform.position = position;
            transform.rotation = rotation;


            Vector3 direction = targetObj.position - transform.position;
            transform.forward = direction;
        }
        else { 
            Debug.Log("none"); 
        }   
    }
}
