using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownController1 : MonoBehaviour
{
    public GameObject LFoot, RFoot, LHand, BHand;
    public Transform balloonPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        attackPatterns();
        Physics.IgnoreCollision(balloonPrefab.transform.GetChild(10).GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 20), ForceMode2D.Impulse);
            Debug.Log("owpa");
        }
    }

    private IEnumerator attackPatterns()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * 30, ForceMode2D.Impulse);
            Debug.Log("owpa");
        }
        return null;
    }
}
