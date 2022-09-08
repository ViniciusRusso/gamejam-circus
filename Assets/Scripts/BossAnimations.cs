using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimations : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
