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
        lastMode = -1;
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

    public void ThrowCard(Vector3 position, Quaternion rotation, bool bounce){
        GameObject card = Instantiate(ThrowingCard, position, rotation);
        if(bounce)
            card.GetComponent<CardController>().bounceCards = true;
    }

    public int RandomMode(int maxValue){
        int random = Random.Range(0, maxValue);
        while (random == lastMode){
            random = Random.Range(0, maxValue);
        }
        lastMode = random;
        return random;
    }

    public void ThrowMultipleCards (int cardNumber, int pattern, bool bounce, Vector3 position, Quaternion rotation){
        if (pattern == 1)
            StartCoroutine(MultipleCards(cardNumber, bounce, position, rotation));
        else if (pattern == 2)
            StartCoroutine(Pattern2MultipleCards(cardNumber, bounce, position, rotation));
    }

    public IEnumerator MultipleCards(int number, bool bounce, Vector3 position, Quaternion rotation){
        for (int i = 0; i< number; i++){
            ThrowCard(position, rotation,bounce);
            yield return new WaitForSeconds(0.4f);
        }
    }
    public IEnumerator Pattern2MultipleCards(int number, bool bounce, Vector3 position, Quaternion rotation){
        Vector3 pos = position;
        for (int i = 0; i< number; i++){
            ThrowCard(pos, rotation, bounce);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
