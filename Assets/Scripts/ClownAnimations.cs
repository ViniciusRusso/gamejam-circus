using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAnimations : MonoBehaviour
{
    private int lastMode;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        lastMode = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimerCoroutine(float time)
    {
        StartCoroutine(Timer(time));
    }

    private IEnumerator Timer(float idleTime)
    {
        animator.SetBool("TimerEnd", false);
        yield return new WaitForSeconds(idleTime);
        animator.SetBool("TimerEnd", true);
    }

    public int RandomMode(int maxValue)
    {
        int random = Random.Range(0, maxValue);
        while (random == lastMode)
        {
            random = Random.Range(0, maxValue);
        }
        lastMode = random;
        return random;
    }

    public void throwBalls(Vector2 startPos)
    {

    }


}
