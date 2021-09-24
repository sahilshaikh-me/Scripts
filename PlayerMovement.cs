using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Speed =4;
    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float Hori = Input.GetAxis("Horizontal") * Speed ;
        float Ver = Input.GetAxis("Vertical") * Speed;
      //  Vector3 Movement = new Vector3(Hori, 0, Ver) ;
        //  transform.Translate(Movement);
        rb.velocity = (transform.forward * Ver) + (transform.right * Hori) + (transform.up * rb.velocity.y);
    }
}
