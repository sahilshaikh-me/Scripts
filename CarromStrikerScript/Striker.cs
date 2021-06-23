using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    [SerializeField] Slider SliderStriker;
 
      public  bool CanShot;
    public GameObject ScalePower;
    public Rigidbody2D rb;
   public float ShotSpeed;
    float MaxSpeed;
    private void Start()
    {
        SliderStriker.onValueChanged.AddListener(StrikerXPos);
        rb.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (CanShot)
        {
            Debug.Log("Down ...");
            Vector3 mouseposition = Input.mousePosition;
            mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
            Vector2 Direction = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);
            float MaxSpeed = Direction.magnitude;
            MaxSpeed = Mathf.Clamp(Direction.magnitude, 0, 5);
            transform.up = Direction* MaxSpeed;
            Debug.Log(MaxSpeed+" :ShotForce");
            ScalePower.transform.localScale = new Vector3(MaxSpeed+1,MaxSpeed+1,MaxSpeed+1);
            ShotSpeed = MaxSpeed;
        }

       


       if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Up ...");
        } 
    }
    private void OnMouseDown()
    {
        CanShot = true;
        ScalePower.SetActive(true);
    }
    private void OnMouseUp()
    {
        CanShot = false;
        ScalePower.SetActive(false);
        rb.AddForce(ScalePower.transform.forward * ShotSpeed,ForceMode2D.Impulse);
    }


    public void StrikerXPos(float value)
    {
        transform.position = new Vector3(value, 0, 0);
    }
}
