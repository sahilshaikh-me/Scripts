using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public static Jump Instance { get; set; }
    public bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        jump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        jump = false;
    }
}
