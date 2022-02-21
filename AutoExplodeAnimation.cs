using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;



public class AutoExplodeandCloapse : MonoBehaviour
{
    public static ExplodeAnimation Instance { get; set; }
    public float Speed;
    public bool isExplode;
    public List<Vector3> StartPos;
    [System.Serializable]
    public class ExplodedViewdataClass 
    {
        public static ExplodedViewdataClass Instance { get; set; }
        public GameObject obj ;
      
        public enum DirectionTest { Up, Down, Right, Left, Forward, Backward }
        public float Offset = Random.Range(1,5);
        public DirectionTest direction = (DirectionTest)Random.Range(0,5);
        
        
    }
    public   ExplodedViewdataClass[] ExplodedViewdataClasses;

   public Transform[] ChildObjects;


    void Start()
    {
       
         ExplodedViewdataClasses = new ExplodedViewdataClass[transform.childCount];
      
      ChildObjects = new Transform[transform.childCount];
        for (int i = 0; i < ChildObjects.Length; i++)
        {
           ChildObjects[i] = gameObject.transform.GetChild(i) ;

            ChildObjects[i].name = "Cube" +i;

        }

        for (int i = 0; i < ExplodedViewdataClasses.Length; i++)
        {
            StartPos.Add(ChildObjects[i].transform.position);
           
        }




    }

  
   
    void Update()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        for (int j = 0; j < ExplodedViewdataClasses.Length; j++)
        {
            ExplodedViewdataClasses[j].obj = GameObject.Find("Cube" + j);
           
           
          

        }
        if (isExplode)
        {

            for (int i = 0; i < ExplodedViewdataClasses.Length; i++)
            {

               switch (ExplodedViewdataClasses[i].direction)
                {
                    case ExplodedViewdataClass.DirectionTest.Left:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position
                            , new Vector3(-ExplodedViewdataClasses[i].Offset, ExplodedViewdataClasses[i].obj.transform.position.y, ExplodedViewdataClasses[i].obj.transform.position.z),
                            Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Right:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position,
                            new Vector3(ExplodedViewdataClasses[i].Offset, ExplodedViewdataClasses[i].obj.transform.position.y, ExplodedViewdataClasses[i].obj.transform.position.z),
                            Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Up:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position,
                            new Vector3(ExplodedViewdataClasses[i].obj.transform.position.x, ExplodedViewdataClasses[i].Offset, ExplodedViewdataClasses[i].obj.transform.position.z),
                            Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Down:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position,
                            new Vector3(ExplodedViewdataClasses[i].obj.transform.position.x, -ExplodedViewdataClasses[i].Offset, ExplodedViewdataClasses[i].obj.transform.position.z),
                            Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Backward:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position,
                            new Vector3(ExplodedViewdataClasses[i].obj.transform.position.x, ExplodedViewdataClasses[i].obj.transform.position.y, -ExplodedViewdataClasses[i].Offset),
                            Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Forward:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position,
                            new Vector3(ExplodedViewdataClasses[i].obj.transform.position.x, ExplodedViewdataClasses[i].obj.transform.position.y, ExplodedViewdataClasses[i].Offset),
                            Time.deltaTime * Speed);
                        break;
                }

            }
        }
        if (!isExplode)
        {
            for (int i = 0; i < ExplodedViewdataClasses.Length; i++)
            {
                ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, StartPos[i], Time.deltaTime * Speed);
            }
        }

    }

    public void ExplodeM()
    {

        isExplode = !isExplode;
    }

}//////