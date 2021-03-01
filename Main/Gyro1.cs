using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    public bool gyroEnable;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        cameraContainer = new GameObject("CameraCont");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnable = EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnable)
        {
            transform.localRotation = gyro.attitude * rot;
        }

      //  transform.Translate(0, 0, -Input.acceleration.z *2);
        

    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(90, 90, 0);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;


    }

}
