using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public bool isGrounded;
    public LayerMask whatisGround;
   
    public CapsuleCollider col;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Jump.Instance.jump == true&& JumpFun())
        {
            anim.SetTrigger("Jump");
           
        }
        if (!JumpFun())
        {
            anim.SetTrigger("Fall");
        }
            if (RightButton.Instance.MoveRight)
        {
            this.gameObject.transform.Translate(Vector3.forward * 7f * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetBool("Walk", true);
        }
        if (RightButton.Instance.MoveRight == false&& LeftButton.Instance.MoveLeft==false)
        {
            anim.SetBool("Walk", false);
        }
        if (LeftButton.Instance.MoveLeft)
        {
            this.gameObject.transform.Translate(Vector3.forward * 7f * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetBool("Walk", true);
        }
    }

   public bool JumpFun()
    {
       return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, 
            col.bounds.min.y, col.bounds.center.z),col.radius*.9f,whatisGround);
     

    }
    public void AnimJump()
    {
       
            rb.AddForce(Vector3.up * 10,ForceMode.Impulse);
          
     
    }
}
