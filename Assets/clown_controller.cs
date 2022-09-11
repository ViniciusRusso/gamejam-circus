using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clown_controller : StateMachineBehaviour
{
    string[] triggers = { "Stomp", "JumpsandStomps", "MakeItRain" };
    float lowerTimeLimit, higherTimeLimit;
    public float idleTime = 3.5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int num = 3;
        animator.SetInteger("StateInt", animator.GetComponent<ClownAnimations>().RandomMode(num));
        animator.GetComponent<ClownAnimations>().StartTimerCoroutine(idleTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*if (animator.GetBool("TimerEnd"))
        {
            int randomState = Random.Range(0, 2);
            animator.SetTrigger(triggers[randomState]);
            Debug.Log(triggers[randomState]);
        }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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
