using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ragdoll : MonoBehaviour {

    Rigidbody[] rigidbodies;
    public Animator anim;
    public GameObject Scripts;
    void Awake ()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        DoRagdoll(true);
    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoRagdoll(false);
            this.gameObject.GetComponent<Zombie>().enabled = false;
        }
       
    }
    public void DoRagdoll(bool isRagdoll)
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = isRagdoll;
            anim.enabled = isRagdoll;
            rb.useGravity = !isRagdoll;
        
            Debug.Log(isRagdoll);
        }
       
    }


}
