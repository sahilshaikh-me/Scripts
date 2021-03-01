using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class TouchCamera : MonoBehaviour
{
    public Transform Player,Traget;
    float MouseX, MouseY;
  public  float RotateSpeed = 4;
    public Animator anim;
  //  public TextMeshProUGUI SensitivityUi;
    public GameObject TouchScreen;

   
  
 
    void Start()
    {



        TouchScreen.GetComponent<FixedTouchField>();
     
       // anim = GetComponentInParent<Animator>();
       
    }
    private void LateUpdate()
    {
          Player.transform.rotation = Quaternion.Euler(0, MouseX, 0);
        MouseX += TouchScreen.GetComponent<FixedTouchField>().TouchDist.x * Time.deltaTime * RotateSpeed;
        MouseY -= TouchScreen.GetComponent<FixedTouchField>().TouchDist.y * Time.deltaTime * RotateSpeed;
        Traget.transform.rotation = Quaternion.Euler(MouseY, MouseX, 0);
      

        MouseY = Mathf.Clamp(MouseY, -35, 40);



    }
  

}
