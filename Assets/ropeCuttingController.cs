using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeCuttingController : MonoBehaviour
{
    private CharacterController2D cc;
    private float timeStamp;
    public float killCooldown = 3;
    private bool canCut = true;
    private int balloonsCut = 0;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rope" && timeStamp <= Time.time && cc.isDashing == true)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
            timeStamp = Time.time + killCooldown;
        }
    }

    private IEnumerator bossInvincibility()
    {
        yield return new WaitForSeconds(3);
        canCut = true;
    }
}
