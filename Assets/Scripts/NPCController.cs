using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spriteFeliz;
    public Sprite spriteTriste;
    public int npc;   

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Level") < npc){
            spriteRenderer.sprite = spriteTriste;
        }
        else{
            spriteRenderer.sprite = spriteFeliz;
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
