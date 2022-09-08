using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCardBehavior : StateMachineBehaviour
{
    private Quaternion rotation;
    private Vector3 position;
    private Transform hand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("StaffDefeated"))
        {
            int currentCard =  animator.GetInteger("CardCount");
            hand = animator.gameObject.GetComponent<Transform>().GetChild(2);
            position = new Vector3 (hand.position.x - 2.3f, hand.position.y - 1.5f, hand.position.z);
            if (currentCard == 8 || currentCard == 4){
                rotation = Quaternion.Euler(0f, 0f, -240f);
            }
            else if (currentCard == 7 || currentCard == 3){
                rotation = Quaternion.Euler(0f, 0f, -220f);
            }
            else if (currentCard == 6 || currentCard == 2){
                rotation = Quaternion.Euler(0f, 0f, -200f);
            }
            else {
                rotation = Quaternion.Euler(0f, 0f, -180f);
            }
            Debug.Log(position);
            animator.GetComponent<BossAnimations>().ThrowCard(position, rotation);
            animator.SetInteger("CardCount", animator.GetInteger("CardCount") - 1);
        }
        else if (animator.GetBool("StaffDefeated") && !animator.GetBool("CardsDefeated"))
        {
            animator.SetInteger("CardCount", animator.GetInteger("CardCount") - 1);
            hand = animator.gameObject.GetComponent<Transform>().GetChild(2);
            position = new Vector3 (hand.position.x - 2f, hand.position.y - 0.5f, hand.position.z);
            rotation = Quaternion.Euler(0f, 0f, -270f);
            animator.GetComponent<BossAnimations>().ThrowCard(position, rotation);
        }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
