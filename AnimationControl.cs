using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    public bool Explode;
    public MonoBehaviour ExplodeScript;
    public Animator animController;
  //  public GameObject ControllerScript;

   // public MonoBehaviour AnimationCon;
    void Start()
    {
        animController = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (Explode)
        {
           
          //  AnimationControl.Instance.isExplode = true;
            animController.SetBool("isPlay", true);
          //  ControllerScript.SetActive(true);
            

        }
        else
        {
            animController.SetBool("isPlay", false);
          //  AnimationControl.Instance.isExplode = false;

          //  ControllerScript.SetActive(false);
        }
    }
   
    public void PlayAnimation()
    {
        Explode = !Explode;
       
    }
    public void EnableScript()
    {
        ExplodeScript.enabled = true;
    }
    public void DisableScript()
    {
        ExplodeScript.enabled = false;
    }


}/////
