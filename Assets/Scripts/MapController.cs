using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Capa;
    public GameObject Bolha;
    public GameObject Wall;
    //public GameObject EndText;
    public Vector2[] PlayerPosition = 
    {
        new Vector2(-8.42f, -4.485f),
        new Vector2(-0.86f, -4.485f),
        new Vector2(-6.03f, 0.52f),
        new Vector2(3.91f, 2.53f),
    };

    void Awake()
    {
        Player.GetComponent<TrailRenderer>().enabled = false;
        //EndText.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = PlayerPosition[PlayerPrefs.GetInt("Level")];
        
        if(PlayerPrefs.GetInt("Level") >= 1)
        {
            
            Player.GetComponent<PowerUpController>().haveCape = true;
            //Player.GetComponent<TrailRenderer>().enabled = true;
            //Capa.SetActive(true);
        }
        else
        {
            
            Player.GetComponent<PowerUpController>().haveCape = false;
            //Player.GetComponent<TrailRenderer>().enabled = false;
            //Capa.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Level") >= 2)
        {
            Wall.SetActive(false);
            Player.GetComponent<PowerUpController>().haveBalloon = true;
            //Bolha.SetActive(true);
        }
        else
        {
            Wall.SetActive(true);
            Player.GetComponent<PowerUpController>().haveBalloon = false;
            //Bolha.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Level") >= 3){
            //EndText.SetActive(true);
            SceneManager.LoadScene("Endgame");
        }
        else{
            //EndText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
