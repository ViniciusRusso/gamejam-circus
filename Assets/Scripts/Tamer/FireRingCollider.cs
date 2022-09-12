using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingCollider : MonoBehaviour
{
    private BossTamerController btc;

    // Start is called before the first frame update
    void Start()
    {
        btc = GameObject.Find("BossTamerController").GetComponent<BossTamerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            btc.BossDefeated();
        }
    }
}
