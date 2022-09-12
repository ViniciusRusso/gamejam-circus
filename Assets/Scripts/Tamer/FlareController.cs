using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareController : MonoBehaviour
{
    private Transform mainFlare;
    public float duration;

    private BossTamerController btc;

    // Start is called before the first frame update
    void Start()
    {
        mainFlare = GameObject.Find("MainFlare").GetComponent<Transform>();
        btc =  GameObject.Find("BossTamerController").GetComponent<BossTamerController>();
        StartCoroutine(LerpPosition(mainFlare.position, duration));
    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        yield return new WaitForSeconds(1f);
        float time = 0;
        Vector2 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        
        if(btc.flareCount == 0){
            mainFlare.localScale = new Vector3 (0.5f, 0.5f, 0f);
        }
        else {
            mainFlare.localScale += new Vector3 (0.2f, 0.2f, 0f);
        }     
        btc.flareCount++;
        gameObject.SetActive(false);
    }
}
