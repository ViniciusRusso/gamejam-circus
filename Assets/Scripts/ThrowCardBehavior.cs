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
            hand = animator.gameObject.GetComponent<Transform>().GetChild(1);
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
                rotation = Quaternion.Euler(0f, 0f, -170f);
            }
            //Debug.Log(position);
            //animator.GetComponent<BossAnimations>().ThrowCard(position, rotation);
            animator.GetComponent<BossAnimations>().ThrowMultipleCards(2, 1, false, position, rotation);
            animator.SetInteger("CardCount", animator.GetInteger("CardCount") - 1);
        }
        else if (animator.GetBool("StaffDefeated") && !animator.GetBool("CardsDefeated"))
        {
            if (animator.GetInteger("NextAttack") == 0){

                float extra;
                if (animator.GetInteger("CardCount")%2 == 0){
                    extra = 0f;
                }
                else{
                    extra = 2f;
                }
                animator.SetInteger("CardCount", animator.GetInteger("CardCount") - 1);
                hand = animator.gameObject.GetComponent<Transform>().GetChild(1);
                position = new Vector3 (hand.position.x - 2.7f, hand.position.y + extra, hand.position.z);
                rotation = Quaternion.Euler(0f, 0f, -270f);
                animator.GetComponent<BossAnimations>().ThrowCard(position, rotation, false);
            }
            else if (animator.GetInteger("NextAttack") == 1)
            {
                
                animator.SetInteger("CardCount", animator.GetInteger("CardCount") - 1);
                hand = animator.gameObject.GetComponent<Transform>().GetChild(1);
                position = new Vector3 (hand.position.x - 2.7f, hand.position.y, hand.position.z);
                rotation = Quaternion.Euler(0f, 0f, -270f);
                animator.GetComponent<BossAnimations>().ThrowMultipleCards(1, 2, false, position, rotation);
            }
            else if (animator.GetInteger("NextAttack") == 2){
                int currentCard =  animator.GetInteger("CardCount");
                hand = animator.gameObject.GetComponent<Transform>().GetChild(1);
                position = new Vector3 (hand.position.x - 2.3f, hand.position.y - 1.5f, hand.position.z);
                if (currentCard == 8 || currentCard == 4){
                    rotation = Quaternion.Euler(0f, 0f, -240f);
                }
                else if (currentCard == 7 || currentCard == 3){
                    rotation = Quaternion.Euler(0f, 0f, -230f);
                }
                else if (currentCard == 6 || currentCard == 2){
                    rotation = Quaternion.Euler(0f, 0f, -220f);
                }
                else {
                    rotation = Quaternion.Euler(0f, 0f, -210f);
                }
                //Debug.Log(position);
                //animator.GetComponent<BossAnimations>().ThrowCard(position, rotation);
                animator.GetComponent<BossAnimations>().ThrowMultipleCards(2, 1, true, position, rotation);
                animator.SetInteger("CardCount", animator.GetInteger("CardCount") - 1);
            }
        }
        else if (animator.GetBool("StaffDefeated") && animator.GetBool("CardsDefeated")){
            animator.SetInteger("CardCount", animator.GetInteger("CardCount") - 1);
            Transform hat = animator.gameObject.GetComponent<Transform>().GetChild(0);
            position = hat.position;
            Vector3 pos1 = position + new Vector3 (0f, -3f, 0f);
            Vector3 pos2 = position + new Vector3 (-1.5f, -3f, 0f);
            Vector3 pos3 = position + new Vector3 (1.5f, -3f, 0f);
            Quaternion rot1 = Quaternion.Euler(0f, 0f, 180f);
            Quaternion rot2 = Quaternion.Euler(0f, 0f, 130f);
            Quaternion rot3 = Quaternion.Euler(0f, 0f, 220f);
            animator.GetComponent<BossAnimations>().ThrowMultipleCards(2, 1, true, pos1, rot1);
            animator.GetComponent<BossAnimations>().ThrowMultipleCards(2, 1, true, pos2, rot2);
            animator.GetComponent<BossAnimations>().ThrowMultipleCards(2, 1, true, pos3, rot3);
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
