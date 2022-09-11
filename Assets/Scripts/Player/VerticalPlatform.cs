using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private BoxCollider2D col;
    private bool playerOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform && Input.GetAxisRaw("Vertical") < 0){
            col.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider(){
        yield return new WaitForSeconds(0.4f);
        col.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value){
        if (other.gameObject.tag == "Player"){
            playerOnPlatform = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other) {
        SetPlayerOnPlatform(other, false);
    }
}
