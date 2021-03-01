using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollision : MonoBehaviour
{
    public Rigidbody rb;
    public AxeFinal Axe;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Axe.CollistionOccured();
        rb.useGravity = false;
        rb.isKinematic = true;
    }
   public void AddConstraints()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }
   public void RemoveConstraints()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}
