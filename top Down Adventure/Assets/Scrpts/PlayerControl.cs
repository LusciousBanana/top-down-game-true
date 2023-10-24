using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // importing SceneManagement Library

public class PlayerControl : MonoBehaviour
{
    public float speed = 0.5f;
    public bool haskey = false;
    public bool hasHammer = false;
    public GameObject key;
    public GameObject BigHammer;
    public static PlayerControl instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 newPosition = transform.position;

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            //player moves up
            newPosition.y += speed;
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            //player moves down
            newPosition.y -= speed;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            //player moves left
            newPosition.x -= speed;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            //player moves right
            newPosition.x += speed;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Door"))
        {
            if (haskey)
            {
                Debug.Log("hit");
                SceneManager.LoadScene("indoors");
            } else
            {
                Debug.Log("get the key you fool");
            }
               

        }
        if (collision.gameObject.tag.Equals("Door2"))
        {
            Debug.Log("touch Grass");
            SceneManager.LoadScene("Outdoors");
        }
        if (collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("I has a keys");
            key.SetActive(false); // key dissapears'
            haskey = true;
        }
        if (collision.gameObject.tag.Equals("Stairs"))
        {
            
            SceneManager.LoadScene("InnerIndoors");
            
            
        }
        if (collision.gameObject.tag.Equals("Upstairs"))
        {
            SceneManager.LoadScene("indoors");
        }
        if (collision.gameObject.tag.Equals("BigHammer"))
        {
            hasHammer = true;
        }
        if (collision.gameObject.tag.Equals("Exit"))
            {
            if (hasHammer)
            {
                SceneManager.LoadScene("The End");
                BigHammer.SetActive(false);
            }
        }
    }
  
}
