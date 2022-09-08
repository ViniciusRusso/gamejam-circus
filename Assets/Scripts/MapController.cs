using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject Player;
    public Vector2[] PlayerPosition = 
    {
    new Vector2(-8.42f, -4.485f),
    new Vector2(-0.86f, -4.485f),
    new Vector2(-6.03f, 0.52f),
    new Vector2(3.91f, 2.53f),
    };

    void Awake()
    {
        Player.transform.position = PlayerPosition[PlayerPrefs.GetInt("Level")];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
