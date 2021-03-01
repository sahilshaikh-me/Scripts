using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
  
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    void LateUpdate()
    {
        if (Vector3.Distance(Player.transform.position,transform.position ) < 10)
        {
            Vector3 direction = Player.transform.position - transform.position ;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if(direction.magnitude > 5)
            {
                transform.Translate(0,0,0.05f);
            }


        }
        


    }
}
