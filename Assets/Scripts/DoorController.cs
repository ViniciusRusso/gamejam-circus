using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private GameObject musicObj; 
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            int proxLvl = PlayerPrefs.GetInt("Level") + 1;
            PlayerPrefs.SetInt("Level", proxLvl);
            // stopMusic();
            SceneManager.LoadScene("Map");
        }
    }

    private void stopMusic()
    {
        musicObj = GameObject.Find("AudioSource");
        audio = musicObj.GetComponent<AudioSource>();
        // Debug.Log(musicObj.GetComponent<AudioSource>().clip);
        GetComponent<AudioSource>().Stop();
    }
}
