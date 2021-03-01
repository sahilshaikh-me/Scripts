using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour
{
    public GameObject WebCamPlane;
    // Start is called before the first frame update
    void Start()
    {

        if(Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.up, 90);
        }

        Input.gyro.enabled = true;

        WebCamTexture webCamTexture = new WebCamTexture();
        WebCamPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion camRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = camRotation;
    }
}
