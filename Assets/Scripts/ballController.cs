using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballController : MonoBehaviour
{ 
    public float Speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemy" && other.tag != "Rope")
        {
            if(other.gameObject.tag == "Player")
            {
                Debug.Log("Player Hit");
                Destroy(gameObject);
                SceneManager.LoadScene("Boss2");
            }     
            Destroy(gameObject);
        }
    }
}
