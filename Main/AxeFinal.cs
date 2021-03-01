using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeFinal : MonoBehaviour
{
    public GameObject axe;
    public Rigidbody rb;
    public GameObject axeTempHolder;
    public float axeFlightSpeed = 10f;
    public float axeThrowPower = 10;
    public float axeRotationSpeed = 10;
    public GameObject player;
    public AxeCollision AxeCollision;
    public enum AxeState { Static,Thrown,Travelling,Returning}
    public AxeState axeState;

    private float startTime;
    private float journeyTime;
    private Vector3 StartPos;
    private Vector3 endPos;
    float journeyLength;
    public BoxCollider AxeCollider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = axe.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            axeState = AxeState.Thrown;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartPos = axe.transform.position;
            endPos = axeTempHolder.transform.position;
            startTime = Time.time;
            journeyLength = Vector3.Distance(StartPos, endPos);
            axeState = AxeState.Returning;
        }
        if(axeState == AxeState.Thrown)
        {
            ThrownAxeWithPhysic();
        }

        if(axeState == AxeState.Travelling || axeState == AxeState.Returning)
        {
            axe.transform.Rotate(6.0f * axeRotationSpeed * Time.deltaTime, 0, 0);
        }
        if(axeState == AxeState.Returning)
        {
            RecallAxe();
        }
    }

    void ThrownAxeWithPhysic()
    {
        axe.transform.parent = null;
        axeState = AxeState.Travelling;
        rb.isKinematic = false;
      //  rb.useGravity = true;
        rb.AddForce(Camera.main.transform.forward * axeThrowPower);
        AxeCollider.enabled = true;
    }
    void RecallAxe()
    {
        AxeCollider.enabled = false;
        float disCovered = (Time.time - startTime) * axeFlightSpeed;
        float fracJourney = disCovered / journeyLength;
        axe.transform.position = Vector3.Lerp(StartPos, endPos, fracJourney);
        if(fracJourney >= 1.0f)
        {
            RecalledAxe();
        }
    }
    void RecalledAxe()
    {

        axeState = AxeState.Static;
        AxeCollision.RemoveConstraints();
        axe.transform.position = axeTempHolder.transform.position;
        axe.transform.rotation = axeTempHolder.transform.rotation;
        rb.isKinematic = true;
        rb.useGravity = false;
        axe.transform.parent = this.transform;
    }
    public void CollistionOccured()
    {
        axeState = AxeState.Static;
    }


}/////
