using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class LatLong : MonoBehaviour
{
    public static LatLong Instance { get; set; }
    public Text gpsOut;
    public bool isUpdating;
    public float Latitude, longitude;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocation());
    }
    private void Update()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private IEnumerator StartLocation()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(10);
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log(" user has not enable GPS ");
            yield break;
        }
        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if(maxWait <= 0)
        {
            Debug.Log("Timed Out");
            yield break;
        }
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
                
        }
        Latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        yield break;


    }

    #region Location
    //private void Update()
    //{
    //    if (!isUpdating)
    //    {
    //        StartCoroutine(GetLocation());
    //        isUpdating = !isUpdating;
    //    }
    //}
    //IEnumerator GetLocation()
    //{
    //    if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
    //    {
    //        Permission.RequestUserPermission(Permission.FineLocation);
    //        Permission.RequestUserPermission(Permission.CoarseLocation);
    //    }
    //    // First, check if user has location service enabled
    //    if (!Input.location.isEnabledByUser)
    //        yield return new WaitForSeconds(10);

    //    // Start service before querying location
    //    Input.location.Start();

    //    // Wait until service initializes
    //    int maxWait = 10;
    //    while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
    //    {
    //        yield return new WaitForSeconds(1);
    //        maxWait--;
    //    }

    //    // Service didn't initialize in 20 seconds
    //    if (maxWait <1)
    //    {
    //        gpsOut.text = "Timed out";
    //        print("Timed out");
    //        yield break;
    //    }

    //    // Connection has failed
    //    if (Input.location.status == LocationServiceStatus.Failed)
    //    {
    //        gpsOut.text = "Unable to determine device location";
    //        print("Unable to determine device location");
    //        yield break;
    //    }
    //    else
    //    {
    //        gpsOut.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + 100f + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
    //        // Access granted and location value could be retrieved
    //        print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
    //    }

    //    // Stop service if there is no need to query location updates continuously
    //    isUpdating = !isUpdating;
    //    Input.location.Stop();
    //}
    #endregion


}
