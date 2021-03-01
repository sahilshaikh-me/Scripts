using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleInputNamespace;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = SimpleInput.GetAxis(PreDefine.Instance.Horizontal);
        float _vertical = SimpleInput.GetAxis(PreDefine.Instance.Vertical);
        Vector3 Movement = new Vector3(Horizontal, 0, _vertical) * MoveSpeed*Time.deltaTime;

        transform.Translate(Movement);
    }
}
