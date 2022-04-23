using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTest : MonoBehaviour
{
  

    float touchesPrevposDiff, touchCurrentPossDiff, ScaleModifier;
    Vector2 firstTouchPrevPos, secondTouchPrevPos;

    Rect notouchable_area;

   
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
                        transform.localScale -= Vector3.one * ScaleModifier * Time.deltaTime;
                        Vector3 newScale = Vector3.zero;
                        newScale.x = Mathf.Clamp(transform.localScale.x, 0.3f, 1f);
                        newScale.y = Mathf.Clamp(transform.localScale.y, 0.3f, 1f);
                        newScale.z = Mathf.Clamp(transform.localScale.z, 0.3f, 1f);
                        transform.localScale = newScale;    
                    }
                    if (touchesPrevposDiff < touchCurrentPossDiff)
                    {
                        //ScaleUp
                        // transform.localScale += new Vector3(transform.localScale.x , transform.localScale.y , transform.localScale.z ) *ScaleModifier * Time.deltaTime;
                        transform.localScale += Vector3.one * ScaleModifier * Time.deltaTime;
                        Vector3 newScale = Vector3.zero;
                        newScale.x = Mathf.Clamp(transform.localScale.x, 1f, 4);
                        newScale.y = Mathf.Clamp(transform.localScale.y, 1f, 4);
                        newScale.z = Mathf.Clamp(transform.localScale.z, 1f, 4);
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
