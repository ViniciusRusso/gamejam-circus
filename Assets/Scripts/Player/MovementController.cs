using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    // Start is called before the first frame update
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")){
            jump =  true;
        }
    }

    void FixedUpdate()
    {
        //Move
           
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
