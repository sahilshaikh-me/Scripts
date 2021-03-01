using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FastEnemyAi
public class FastEnemyAi : MonoBehaviour
{
    public GameObject Player;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.transform.position - this.transform.position;
        // float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(Player.transform.position, transform.position) < 20)
        {

            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.5f);

            Anim.SetBool("isIdel", false);
            if (direction.magnitude > 1)
            {
                this.transform.Translate(0, 0,1.5f * Time.deltaTime);
               // Anim.SetBool("isWalking", true);
                Anim.SetBool("isRun", true);
                Anim.SetBool("isAttack", false);
            }
            else
            {
                Anim.SetBool("isAttack", true);
                Anim.SetBool("isRun", false);

            }
        }
        else
        {
            Anim.SetBool("isIdel", true);
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isAttack", false);
        }
        //if (Vector3.Distance(Player.position, transform.position) < 30 && Vector3.Distance(Player.position, transform.position) >20)
        //{
        //    transform.Translate(0, 0, 10f * Time.deltaTime);
        //    direction.y = 0;
        //    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.5f);

        //    Anim.SetTrigger("JumAttack");



        //}

    }

}
