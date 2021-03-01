using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    public static DoubleClick Instance { get; set; }
    private float firstClickTime, timebetweenClicks;
    public bool coroutineAllowed;
    public int clickCounter;

    // Start is called before the first frame update
    void Start()
    {
        firstClickTime = 0.1f;
        timebetweenClicks = 0.2f;
        clickCounter = 0;
        coroutineAllowed = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        if (Input.GetMouseButtonUp(0) )
        {
            clickCounter += 1;
           

        }

        if(clickCounter == 1 && coroutineAllowed)
        {
           
            firstClickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }
    }
    public IEnumerator DoubleClickDetection()
    {

        coroutineAllowed = false;
        while(Time.time < firstClickTime + timebetweenClicks)
        {

            if(clickCounter == 2)
            {
                Debug.Log("Double Click");
              break;
              
            }
            
            yield return new WaitForEndOfFrame();
           
        }
        clickCounter = 0;
        firstClickTime = 0f;
        coroutineAllowed = true;
    }
}
