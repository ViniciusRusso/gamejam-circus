using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeCuttingController : MonoBehaviour
{
    private float timeStamp;
    public float killCooldown = 0;
    private bool canCut = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rope" && timeStamp <= Time.time)
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
