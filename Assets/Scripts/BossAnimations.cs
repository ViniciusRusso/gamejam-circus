using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimations : MonoBehaviour
{
    public Animator animator;
    public GameObject ThrowingCard;
    
    private int lastMode;

    // Start is called before the first frame update
    void Start()
    {

        //ThrowCard(new Vector3 (0f,0f,0f), new Quaternion (0f, 0f,0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimerCoroutine(float time){
        StartCoroutine(Timer(time));
    }

    private IEnumerator Timer(float idleTime){
        animator.SetBool("TimerEnd", false);
        yield return new WaitForSeconds(idleTime);
        animator.SetBool("TimerEnd", true);
    }

    public void ThrowCard(Vector3 position, Quaternion rotation){
        Instantiate(ThrowingCard, position, rotation);
    }

    
}
