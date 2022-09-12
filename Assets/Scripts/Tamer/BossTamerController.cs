using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTamerController : MonoBehaviour
{
    public GameObject monkey, tiger, elephant, mainFlare, fireRing;
    public Vector3[] monkeyPosition = new Vector3[4];
    public Vector3 tigerPosition;
    public Vector3[] elephantPosition = new Vector3[2];
    public Vector3[] platformPosition = new Vector3[2];

    public Animator animator, tigerAnimator;

    private Quaternion right =  Quaternion.Euler(0f, 180f, 0f);
    private Quaternion left =  Quaternion.Euler(0f, 0f, 0f);

    public int animalsDefeated;
    
    void Awake(){
        animalsDefeated = 0;
        mainFlare.SetActive(true);
        fireRing.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //StartPhase 1    
        StartPhase1();
    }

    // Update is called once per frame
    void Update()
    {
        if (animalsDefeated == 7){
            CreateFireRing();
        }
    }

    private void StartPhase1()
    {
        animator.SetBool("Phase 1 Start", true);
        tigerAnimator.SetBool("Phase 1 Start", true);    }

    public void StartPhase2()
    {
        //Platform coming from sideways animation
        animator.SetBool("Phase 2 Start", true);
        //Instantiate 2 monkeys and 2 elephants
        Instantiate(monkey, monkeyPosition[2], right);
        Instantiate(monkey, monkeyPosition[3], left);
        Instantiate(elephant, elephantPosition[0], left);
        Instantiate(elephant, elephantPosition[1], right);
    }

    private void CreateFireRing(){
        fireRing.SetActive(true);
    }

    public void BossDefeated()
    {
        // If fire ring is passed, trigger
    }

}
