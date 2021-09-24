using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //FpsCamera
    public float mouseSensitivity = 100f;
    public Transform PlayerBody;
    float xRotation = 0f;
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
      //  transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
       transform.localEulerAngles = new Vector3(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }



}//////
