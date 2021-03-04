using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    public GameObject Panel;
    public static Player PlaInstance { get; set; }
    // player position 0 0.58 4.26
    public float MoveSpeed;
    public bool SameText;
    
    public float Speed;
    public float SpeedContain;

   
 
    // Start is called before the first frame update
    void Start()
    {
        SameText = false;
       
    }

    // Update is called once per frame
    void Update()

    {
        if (Instance == null) {
            Instance = this;
        }

        DontDestroyOnLoad(this);
        if(PlaInstance == null)
        {
            PlaInstance = this;
        }
        float h = Input.GetAxis("Horizontal") * 8 * Time.deltaTime;
        transform.Translate(h, 0, 0);
     

        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.95f, 1.80f), transform.position.y, transform.position.z);
        //  transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -1.075f, 1.13f), transform.position.z);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 TouchPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(TouchPosition.x * Speed * Time.deltaTime, 0, 0);
        }
    }
    private void LateUpdate()
    {
        SpeedContain += Time.deltaTime;
        MoveSpeed += Time.deltaTime;
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            SameText = true;
           // SceneManager.LoadScene("Start");
            Destroy(gameObject);
            Time.timeScale = 0.5f;
            Panel.SetActive(true);
           
        }
    }
   
}
