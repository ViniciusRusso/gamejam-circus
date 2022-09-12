using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTamerController : MonoBehaviour
{
    public GameObject mainFlare, fireRing;


    public Animator animator, tigerAnimator;

    [HideInInspector] public int animalsDefeated;
    [HideInInspector] public int flareCount;

    void Awake(){
        animalsDefeated = 0;
        flareCount = 0;
        mainFlare.SetActive(true);
        fireRing.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartPhase 1    
        //StartCoroutine(Phase1());
        StartPhase1();
    }

    // Update is called once per frame
    void Update()
    {
        if (flareCount == 7){
            CreateFireRing();
        }
    }

    private void StartPhase1()
    {
        animator.SetBool("Phase 1 Start", true);
        tigerAnimator.SetBool("Phase 1 Start", true);    
    }

    private IEnumerator Phase1(){
        yield return new WaitForSeconds(2f);
        StartPhase1();
    }

    public void StartPhase2()
    {
        //Platform coming from sideways animation
        animator.SetBool("Phase 2 Start", true);
    }

    private void CreateFireRing(){
        mainFlare.SetActive(false);
        fireRing.SetActive(true);
    }

    public void BossDefeated()
    {
        // If fire ring is passed, trigger

        Debug.Log("Win");
    }

}
