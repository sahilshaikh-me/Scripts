using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject mousePointA;
    private GameObject mousePointB;
    private GameObject arrow;
    private GameObject Circle;


    private float currentdistance;
    public float maxDistance = 3f;
    private float safeSpace;
    private float shootpower;


    private Vector3 shootDirection;
    // Start is called before the first frame update
    void Start()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");
        mousePointB = GameObject.FindGameObjectWithTag("PointB");
        arrow = GameObject.FindGameObjectWithTag("arrow");
        Circle = GameObject.FindGameObjectWithTag("Circle");

    }
    private void OnMouseDrag()
    {
        currentdistance = Vector3.Distance(mousePointA.transform.position, transform.position);

        if (currentdistance <= maxDistance)
        {
            safeSpace = currentdistance;
        }
        else
        {
            safeSpace = maxDistance;
        }
        doArrowAndCircleStuff();

        shootpower = Mathf.Abs(safeSpace) * 13;
        Vector3 dimxy = mousePointA.transform.position - transform.position;
        float diffrence = dimxy.magnitude;
        mousePointB.transform.position = transform.position + ((dimxy / diffrence) * currentdistance * -1);
        mousePointB.transform.position = new Vector3(mousePointB.transform.position.x, mousePointB.transform.position.y, -0.8f);
        shootDirection = Vector3.Normalize(mousePointA.transform.position - transform.position);

    }

    private void doArrowAndCircleStuff()
    {
        arrow.GetComponent<MeshRenderer>().enabled = true;
        Circle.GetComponent<MeshRenderer>().enabled = true;
        if(currentdistance <= maxDistance)
        {
            arrow.transform.position = new Vector3((2 * transform.position.x) - mousePointA.transform.position.x, (2 * transform.position.y)- mousePointA.transform.position.y,-1.8f);
        }
        else
        {
            Vector3 dimxy = mousePointA.transform.position - transform.position;
            float diffrence = dimxy.magnitude;
            arrow.transform.position = transform.position + ((dimxy / diffrence) * maxDistance * -1);
            arrow.transform.position = new Vector3(arrow.transform.position.x, arrow.transform.position.y, -1.5f);
        }

        Circle.transform.position = transform.position + new Vector3(0, 0, 0.05f);
        Vector3 dir = mousePointA.transform.position - transform.position;
        float rot;
        if (Vector3.Angle(dir, transform.forward) > 90)
        {
            rot = Vector3.Angle(dir, transform.right);

        }
        else
        {
            rot = Vector3.Angle(dir, transform.right)*-1;
        }
        arrow.transform.eulerAngles = new Vector3(0, 0, rot);

        float ScaleX = Mathf.Log(1 + safeSpace / 2, 2) * 2.2f;
        float ScaleY = Mathf.Log(1 + safeSpace / 2, 2) * 2.2f;

        arrow.transform.localScale = new Vector3(1 + ScaleX, 1 + ScaleY, 0.001f);
        Circle.transform.localScale = new Vector3(1 + ScaleX, 1 + ScaleY, 0.001f);

    }

    // Update is called once per frame
    void OnMouseUp()
    {
        Vector3 push = shootDirection * shootpower*-1;
        GetComponent<Rigidbody>().AddForce(push,ForceMode.Impulse);
        arrow.GetComponent<MeshRenderer>().enabled = false;
        Circle.GetComponent<MeshRenderer>().enabled = false;

    }
}
