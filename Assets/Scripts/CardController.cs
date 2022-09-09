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

    public bool bounceCards = false;
    private Vector2 LastVelocity;


    // Start is called before the first frame update
    void Awake()
    {
        //bounceCards = true;
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = RandomCard();
        rb.AddForce(t.up * cardVelocity, ForceMode2D.Impulse);
        //Debug.Log(t.rotation.z); 
   }

    // Update is called once per frame
    void Update()
    {

        
        LastVelocity = rb.velocity;
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
            Flip(other);
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

    private void Flip(Collision2D other)
    {
        
        var speed = LastVelocity.magnitude;
        var direction = Vector2.Reflect(LastVelocity.normalized, other.contacts[0].normal);
        //rb.velocity=direction*Mathf.Max(speed, 0f);
        t.rotation = Quaternion.FromToRotation(t.up, direction);
    }
}
