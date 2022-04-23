using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTest : MonoBehaviour
{
  

    float touchesPrevposDiff, touchCurrentPossDiff, ScaleModifier;
    Vector2 firstTouchPrevPos, secondTouchPrevPos;

    Rect notouchable_area;
    public Vector3 min = new Vector3(0.3f, 0.3f, 0.3f);
    public Vector3 max = new Vector3(4f, 4f, 4f);
   
    private void Start()
    {
        notouchable_area = new Rect(getX(-50.2f), getY(390.3f), getX(1100), getY(180));
    }
    void Update()
    {
        if (!notouchable_area.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
        {
            #region Touchcallbacks
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    // debugToch.text = " Finger one began";
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    float Xaxis = Input.GetAxis("Mouse X");
                    transform.Rotate(0, -Xaxis * 90 * Time.deltaTime, 0);

                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    // debugToch.text = " Finger one Ended";

                }
            }
            //    if(Input.GetTouch(1).phase == TouchPhase.Began)
            //    {
            //        debugToch.text = " Finger Two began";
            //    } 
            //    if(Input.GetTouch(1).phase == TouchPhase.Moved)
            //    {
            //        debugToch.text = " Finger two moved";

            //    }
            //    if (Input.GetTouch(1).phase == TouchPhase.Ended)
            //    {
            //        debugToch.text = " Finger two Ended";

            //    }
            //}
            #endregion

            if (Input.touchCount == 2)
            {
                Touch firstTouch = Input.GetTouch(0);
                Touch secondTouch = Input.GetTouch(1);

                firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
                secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

                touchesPrevposDiff = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                touchCurrentPossDiff = (firstTouch.position - secondTouch.position).magnitude;

                ScaleModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * 0.1f;
                if (Input.GetTouch(1).phase == TouchPhase.Moved && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (touchesPrevposDiff > touchCurrentPossDiff)
                    {
                        //ScaleDown
                        //  transform.localScale -= new Vector3(transform.localScale.x * ScaleModifier, transform.localScale.y * ScaleModifier, transform.localScale.z * ScaleModifier) * Time.deltaTime;
                      //  transform.localScale -= Vector3.one * ScaleModifier * Time.deltaTime;
                          Vector3 newScale = new Vector3();
                        newScale.x = Mathf.Clamp(transform.localScale.x - ScaleModifier, min.x, max.x);
                        newScale.y = Mathf.Clamp(transform.localScale.y - ScaleModifier, min.y, max.y);
                        newScale.z = Mathf.Clamp(transform.localScale.z - ScaleModifier, min.z, max.z);
                        transform.localScale = newScale;   
                    }
                    if (touchesPrevposDiff < touchCurrentPossDiff)
                    {
                        //ScaleUp
                        // transform.localScale += new Vector3(transform.localScale.x , transform.localScale.y , transform.localScale.z ) *ScaleModifier * Time.deltaTime;
                       // transform.localScale += Vector3.one * ScaleModifier * Time.deltaTime;
                       Vector3 newScale = new Vector3();
                        newScale.x = Mathf.Clamp(transform.localScale.x + ScaleModifier, min.x, max.x);
                        newScale.y = Mathf.Clamp(transform.localScale.y + ScaleModifier, min.y, max.y);
                        newScale.z = Mathf.Clamp(transform.localScale.z + ScaleModifier, min.z, max.z);
                        transform.localScale = newScale;
                    }
                }
            }

        }
    }
    public float getY(float valY)
    {
        float y = (valY / 480) * 100;
        return (y / 100) * Screen.height;
    }
    public float getX(float valX)
    {
        float x = (valX / 800) * 100;
        return (x / 100) * Screen.width;
    }
    void OnGUI()
    {
        GUI.Box(notouchable_area, "");
    }

}
