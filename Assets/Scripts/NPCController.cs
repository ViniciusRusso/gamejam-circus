using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject spriteFeliz;
    public GameObject spriteTriste;
    public int npc;   

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("level") < npc){
            spriteFeliz.SetActive(false);
            spriteTriste.SetActive(true);
        }
        else{
            spriteFeliz.SetActive(true);
            spriteTriste.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
    }
}
