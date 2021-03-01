using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public static RightButton Instance { get; set; }
    public bool MoveRight = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        MoveRight = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MoveRight = false;
    }

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
}
