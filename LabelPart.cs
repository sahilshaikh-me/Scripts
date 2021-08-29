using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LabelPart : MonoBehaviour
{
    public Transform[] ts;
    public GameObject canvasUI;
    public Vector3 Offset ;
    GameObject go;
   public List<GameObject> gameObjectsLabel;
    void Start()
    {
      
         ts = gameObject.GetComponentsInChildren<Transform>();
        SpawnLabel();
    }

    void Update()
    {
      
        LineRenderer();
    }
    public void SpawnLabel()
    {
        for (int i = 0; i < ts.Length; i++)
        {


            go = Instantiate(canvasUI, ts[i].transform.position + Offset, Quaternion.Euler(0, 0, 0));
            go.transform.SetParent(ts[i]);

            // go.transform.SetParent(gameObject.transform);
            go.GetComponentInChildren<Text>().text = ts[i].transform.name;
            gameObjectsLabel.Add(go);






        }
    }
    public void LineRenderer()
    {
        for (int i = 0; i < gameObjectsLabel.Count; i++)
        {
            gameObjectsLabel[i].GetComponent<LineRenderer>().SetPosition(0, ts[i].position);
            gameObjectsLabel[i].GetComponent<LineRenderer>().SetPosition(1, gameObjectsLabel[i].transform.position);
        }

    }




}////



public class TestClass : LabelPart
{


    public GameObject target;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = target.transform.position;
    }


}