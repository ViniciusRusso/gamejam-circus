using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Capa;
    public GameObject Bolha;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = PlayerPosition[PlayerPrefs.GetInt("Level")];
        
        if(PlayerPrefs.GetInt("Level") >= 1)
        {
            Player.GetComponent<TrailRenderer>().enabled = true;
            Capa.SetActive(true);
        }
        else
        {
            Player.GetComponent<TrailRenderer>().enabled = false;
            Capa.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Level") >= 2)
        {
            Bolha.SetActive(true);
        }
        else
        {
            Bolha.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
