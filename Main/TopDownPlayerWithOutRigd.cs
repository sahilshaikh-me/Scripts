using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance { get; set; }
    private float RunSpeed =5;
    public float Horizontal;
    public float Verticle;

    public int CountAttack;
    public Animator anim;
    private float rotationSpeed =10;
    private string[] sattack = { "S1", "S2", "S3" };

    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
       

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (RollBtn.Instance.Roll.Equals(true))
        {
            rb.velocity = transform.forward * 11f;
           
            anim.Play("Roll");
            
        }
      
        if (SwordBtn.Instance.AttackSword.Equals( true))
        {
            rb.velocity = transform.forward * 5f;
            CountAttack++;

          
        }
        //if(CountAttack == 1)
        //{

        //    anim.Play(sattack[0]);
          
        //}
        //if(CountAttack == 2)
        //{
        //    anim.Play(sattack[1]);
        //}
        //if (CountAttack == 3)
        //{
        //    anim.Play(sattack[2]);
        //    CountAttack = 0;
        //}
    }
   
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Movement();
        
       
    }
    public void Movement()
    {
        Horizontal = SimpleInput.GetAxis("Horizontal");
        Verticle = SimpleInput.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(Horizontal, 0, Verticle);
       
        if (PlayerMovement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerMovement), rotationSpeed * Time.deltaTime);
        }
       
        rb.MovePosition(transform.position + RunSpeed * Time.deltaTime * PlayerMovement);
        anim.SetFloat("Movement", PlayerMovement.magnitude);
    }
   
}
