using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour,  IDragHandler,IDropHandler,IBeginDragHandler,IEndDragHandler,IEventSystemHandler
{
    public LayerMask floorMask;
   // public GameObject Player;
    Vector3 newPosition;
    //public GameObject unitToSpawn;
   public RaycastHit positionHit;
    public GameObject Player;
    public bool canInsta;
  
    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

    }
    private void Update()
    {
        if(positionHit.point.z >= 0.0f)
        {
            canInsta = false;
        }
        if (positionHit.point.z <= 0.0f)
        {
            canInsta = true;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
       
        //get position we are dragging on in game world
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(camRay, out positionHit, 100, floorMask))
        {

            Debug.Log ("Mouse: " + Input.mousePosition + ", Ray: " + positionHit.point);
           
            newPosition = positionHit.point;
           
        }
       // this.gameObject.transform.position = newPosition;
       
        //unitToSpawn.transform.position = newPosition;

    }

    public void OnDrop(PointerEventData eventData)
    {
      
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(canInsta == true)
        {
            Debug.Log("Drob");
            Instantiate(Player, newPosition, transform.rotation);
        }
        
    }


    // Use this for initialization

}