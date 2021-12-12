using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Siccity.GLTFUtility;
using UnityEngine.Networking;
using LoopXRFramework;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.OpenXR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Animations;

// DOWNLOAD GLB MODELS FROM INTERNET AND LOAD IN SCENE
public class LoadModel : MonoBehaviour
{
   // public List<GameObject> InteractionObj;
    public List<string> Urls;
    public List<Transform> PositionsOfObj;
   
    void Start()
    {
        StartCoroutine(GetText());
    }
    
    IEnumerator GetText()
    {
        Debug.Log("WWW started Start");
      
        for (int i = 0; i < Urls.Count; i++)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(Urls[i]))
            {
                yield return www.Send();
                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    byte[] results = www.downloadHandler.data;
                    Debug.Log("Saved");
                    Debug.Log(results);
                    GameObject obj = Importer.LoadFromBytes(results);
                   // InteractionObj.Add(obj);
                    obj.AddComponent<BoxCollider>();
                    obj.AddComponent<XRGrabInteractable>();
                    obj.GetComponent<XRGrabInteractable>().colliders.Add(gameObject.GetComponent<BoxCollider>());
                    obj.GetComponent<Rigidbody>().isKinematic = true;
                   
                    obj.GetComponent<XRGrabInteractable>().colliders.RemoveAt(obj.GetComponent<XRGrabInteractable>().colliders.Count - 1);
                    obj.AddComponent<InteractEquipment>();
                    obj.AddComponent<ScaleConstraint>();
                    obj.AddComponent<ScaleConstraint>();
                    ConstraintSource source = new ConstraintSource();
                    source.sourceTransform = GameObject.Find("Cube").transform;
                    source.weight = 1;
                    obj.GetComponent<ScaleConstraint>().AddSource(source);
                    obj.GetComponent<ScaleConstraint>().constraintActive = true;
                    //  obj.AddComponent<WindowsGrap>();
                   
                        for (int j = 0; j < PositionsOfObj.Count; j++)
                        {
                             if(PositionsOfObj[j].transform.childCount == 0)
                             {
                                 obj.transform.parent = PositionsOfObj[j].transform;
                            obj.transform.position = PositionsOfObj[j].transform.position;

                             } 
                           
                        }
                    

                    // obj.GetComponent<InteractEquipment>().detailsIfo[0].Label = "Test";
                    //   obj.GetComponent<InteractEquipment>().detailsIfo[0].description = "kjhgsdhfyd";

                    //Debug.Log(obj.GetComponent<InteractEquipment>().detailsIfo.description);

                }
            }
        }
       
    }
    private void Update()
    {
        
    }

}