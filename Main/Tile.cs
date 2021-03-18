using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float Speed;
    public float end;
    public float start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed * Time.deltaTime);
        if (transform.position.z <= end)
        {
            if (gameObject.tag == "Obstacle" || gameObject.tag == "Destroy")
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, start);
            }
          
        }
    }
}
