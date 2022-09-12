using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpController : MonoBehaviour
{
    public CharacterController2D controller;
    public GameObject cape, balloon;
    public int balloonCD;
    public TMP_Text text;

    [HideInInspector] public bool balloonUp = false;

    public bool haveCape;
    public bool haveBalloon;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckPowerUps());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator BalloonCooldown()
    {
        for (int i = balloonCD; i >= 0; i--){
            yield return new WaitForSeconds(1f);
            //text.text = i.ToString();
        }
        
        balloonUp=true;
        balloon.SetActive(true);
    }

    private IEnumerator CheckPowerUps(){
        yield return new WaitForSeconds(0.1f);
        if (haveCape){
            controller.gameObject.GetComponent<TrailRenderer>().enabled = true;
            //cape.SetActive(true);
        }
        else {
            controller.gameObject.GetComponent<TrailRenderer>().enabled = false;
            //cape.SetActive(false);
        }

        if (haveBalloon){
            balloonUp = true;
            controller.canBeDamaged = false;
            balloon.SetActive(true);
        }
        else {
            balloonUp = false;
            controller.canBeDamaged = true;
            balloon.SetActive(false);
        }
    }
}
