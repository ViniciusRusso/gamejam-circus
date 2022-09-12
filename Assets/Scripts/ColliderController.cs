using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour
{
    public GameObject Player;
    public string ColliderName;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Detected");
        if (other.gameObject.tag == "Player")
        {
            if(ColliderName == "poco")
            {
                SceneManager.LoadScene("Map");
            }
            else if(ColliderName == "mago")
            {
                if(PlayerPrefs.GetInt("Level") == 0)
                {
                    SceneManager.LoadScene("Boss1");
                }
            }
            else if(ColliderName == "palhaco")
            {
                if(PlayerPrefs.GetInt("Level") == 1)
                {
                    SceneManager.LoadScene("Boss2");
                }
            }
            else if(ColliderName == "domador")
            {
                if(PlayerPrefs.GetInt("Level") == 2)
                {
                    SceneManager.LoadScene("Boss3");
                }
            }
        }
    }
}
