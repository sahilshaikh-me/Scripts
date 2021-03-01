using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public static LeftButton Instance { get; set; }
    public bool MoveLeft = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MoveLeft = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveLeft = true;
    }
}
