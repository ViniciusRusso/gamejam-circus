using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControlller : MonoBehaviour
{
    private PowerUpController player;
    public GameObject col;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PowerUpController>();        
    }

    // Update is called once per frame
    void Update()
    {
        col.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            if (player.haveBalloon){
                Debug.Log(other.gameObject.tag);
                //col.SetActive(false);
            }
            
        }
    }

}
