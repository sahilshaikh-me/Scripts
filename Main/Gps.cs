using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gps : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LatLong.Instance.gpsOut.text = LatLong.Instance.Latitude.ToString() + " : " + LatLong.Instance.longitude.ToString() ;
       Debug.Log( LatLong.Instance.Latitude.ToString() +"Latitube" + LatLong.Instance.longitude.ToString() + "longitude");
    }

   
}
