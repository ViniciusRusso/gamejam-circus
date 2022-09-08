using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Sprite[] sprites;
    public float cardVelocity;
    public Transform t;
    
    private SpriteRenderer spriteRender;
    private Rigidbody2D rb;

    private bool bounceCards = false;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = RandomCard();
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(t.up * cardVelocity, ForceMode2D.Impulse);
    }

    private Sprite RandomCard()
    {
        int random = Random.Range (0, sprites.Length);
        return sprites[random];
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (bounceCards)
        {
            Flip();
            bounceCards = false;
        }
        else
        {
            if (other.gameObject.tag == "Player"){
                Destroy(gameObject);
            }
            else if (other.gameObject.tag == "Map" || other.gameObject.tag == "Enemy"){
                Destroy(gameObject);
            }
        }
    }

    private void Flip()
    {
        
    }
}
