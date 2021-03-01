using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    #region Fpp Variable
    public float MoveSpeed = 3;
    public Rigidbody rb;
    public float Vertical;
    public float Horizontal;
    #endregion

    #region Tpp Vriable
    public float walkingSpeed = 2;
    public float runSpeed = 6;
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedDmoothVelocity;
    float currentSpeed;
    Transform cameraT;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (TouchCamera.Instance.Fpp == true)
        {

             Horizontal = Input.GetAxis("Horizontal");
             Vertical = Input.GetAxis("Vertical");
            Vector3 Movement = new Vector3(Horizontal, 0, Vertical) * MoveSpeed * Time.deltaTime;

            transform.Translate(Movement);

        }
        else 
        {
            Vector2 inputt = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            Vector2 inputDir = inputt.normalized;

            if(inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,targetRotation,ref turnSmoothVelocity,turnSmoothTime);

            }
            bool running = Input.GetKey(KeyCode.LeftShift);
            float targetSpeed = ((running) ? runSpeed : walkingSpeed) * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedDmoothVelocity, turnSmoothVelocity, speedSmoothTime);
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

           // transform.Translate(Movement);
         


            
        }
    }
}
