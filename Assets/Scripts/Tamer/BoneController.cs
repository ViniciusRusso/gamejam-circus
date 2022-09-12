using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneController : MonoBehaviour
{
    public float throwForce;

    // Start is called before the first frame update
    void Start()
    {
        Transform monkey = GetComponent<Transform>().parent.GetComponent<Transform>();
        Vector2 throwDirection;
        if (monkey.rotation.y == 1f){
            throwDirection = new Vector2 (1f, 1f);
        } 
        else{
            throwDirection= new Vector2 (-1f, 1f);
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        throwDirection = throwDirection * throwForce;
        rb.AddForce(throwDirection, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(280f, 400f);
        
         transform.Rotate (0,0,random*Time.deltaTime); 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
