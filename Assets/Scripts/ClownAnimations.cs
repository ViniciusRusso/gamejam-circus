using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAnimations : MonoBehaviour
{
    private int lastMode;
    public Animator animator;
    public GameObject ballPrefab;
    private GameObject[] balloons;
    public GameObject ExitDoor;

    // Start is called before the first frame update
    void Start()
    {
        lastMode = -1;
    }

    // Update is called once per frame
    void Update()
    {
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
        if (balloons.Length == 0)
        {
            endFight();
        }

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

    public void throwBalls(float posy)
    {
        float ySpawn = 0f;
        float xSpawn = 7.315643f;
        if (posy == 0)
        {
            ySpawn = 1.918263f;
        }
        else if (posy == 1)
        {
            ySpawn = -0.3923749f;
        }
        else
        {
            ySpawn = -3.537f;
        }
        Instantiate(ballPrefab, new Vector2(xSpawn, ySpawn), Quaternion.identity);
        
    }

    public void endFight()
    {
        Debug.Log("HEIR OF FIRE DESTROYED");
        Destroy(gameObject);
        ExitDoor.SetActive(true);
    }
    
        
}



