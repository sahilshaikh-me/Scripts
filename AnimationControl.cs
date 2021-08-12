using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public float Speed;
    public bool isExplode;
  public  List<Vector3> StartPos;
    [System.Serializable]
    public class ExplodedViewdataClass
    {
        public static ExplodedViewdataClass Instance { get; set; }
        public GameObject obj;
        public string name;
        public enum DirectionTest { Up,Down,Right,Left,Forward,Backward}
        public int Offset;
       public DirectionTest direction;
    }
    public ExplodedViewdataClass[] ExplodedViewdataClasses;

    //  public int Offset { get;  set; }
    private void Awake()
    {
       
    }
    void Start()
    {
     //   ExplodedViewdataClass.Instance.direction = ExplodedViewdataClass.DirectionTest.Left;

        for (int i = 0; i < ExplodedViewdataClasses.Length; i++)
        {
            StartPos.Add(ExplodedViewdataClasses[i].obj.transform.position);
            ExplodedViewdataClasses[i].name = ExplodedViewdataClasses[i].obj.name;
        }

    }


    void Update()
    {
        if (isExplode)
        {
            for (int i = 0; i < ExplodedViewdataClasses.Length; i++)
            {
                switch (ExplodedViewdataClasses[i].direction)
                {
                    case ExplodedViewdataClass.DirectionTest.Left:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, new Vector3(-ExplodedViewdataClasses[i].Offset, 0, 0), Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Right:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, new Vector3(ExplodedViewdataClasses[i].Offset, 0, 0), Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Up:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, new Vector3(0, ExplodedViewdataClasses[i].Offset, 0), Time.deltaTime * Speed);
                        break;
                    case ExplodedViewdataClass.DirectionTest.Down:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, new Vector3(0, -ExplodedViewdataClasses[i].Offset, 0), Time.deltaTime * Speed); 
                        break;
                    case ExplodedViewdataClass.DirectionTest.Backward:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, new Vector3(0, 0, -ExplodedViewdataClasses[i].Offset), Time.deltaTime * Speed); 
                        break;
                    case ExplodedViewdataClass.DirectionTest.Forward:
                        ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, new Vector3(0, 0, ExplodedViewdataClasses[i].Offset), Time.deltaTime * Speed);
                        break;
                }

            }
        }
        if (!isExplode)
        {
            for (int i = 0; i < ExplodedViewdataClasses.Length; i++)
            {
                ExplodedViewdataClasses[i].obj.transform.position = Vector3.Lerp(ExplodedViewdataClasses[i].obj.transform.position, StartPos[i],Time.deltaTime*Speed);
            }
        }
       
    }

    public void ExplodeM()
    {
        isExplode = !isExplode;
    }

}//////
