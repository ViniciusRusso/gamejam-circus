using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour
{
    public AudioClip magician, clown, tamer;
    public GameObject Player;
    private AudioSource audio;
    public string ColliderName;
    private GameObject musicObj;

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
                    // magician = Resources.Load<AudioClip>("the_magician");
                    playMusic("the_magician");
                }
            }
            else if(ColliderName == "palhaco")
            {
                if(PlayerPrefs.GetInt("Level") == 1)
                {
                    SceneManager.LoadScene("Boss2");
                    playMusic("the_clown");
                }
            }
            else if(ColliderName == "domador")
            {
                if(PlayerPrefs.GetInt("Level") == 2)
                {
                    SceneManager.LoadScene("Boss3");
                    playMusic("the_tamer");
                }
            }
        }
    }

    private void playMusic(string music)
    {
        musicObj = GameObject.FindGameObjectWithTag("Music");
        audio = musicObj.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>(music);
        // Debug.Log(musicObj.GetComponent<AudioSource>().clip);
        audio.Play();
    }
}
