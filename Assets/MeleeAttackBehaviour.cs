using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBehaviour : StateMachineBehaviour
{    
    public string[] pickAttack = { "Attack1", "Attack2", "Attack3"};
    private string tempAttack;

    public int randomAttack;
    private bool s = true;

    private bool melee = true;

    public GameObject bossStaple;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (s)
        {
            Shuffle();
            s = false;
            
        }

        animator.SetTrigger(pickAttack[randomAttack]);
        randomAttack++;

        if (randomAttack == pickAttack.Length+1)
        {           
            randomAttack = 0;           
            melee = false;
            animator.ResetTrigger("Attack1");
            animator.ResetTrigger("Attack2");
            animator.ResetTrigger("Attack3");
        }



        if (randomAttack <= pickAttack.Length + 1 && melee == true)
        {
            animator.SetTrigger("Attack4");            
            Instantiate(bossStaple);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
           
    }

    public void Shuffle()
    {
        for (int i = 0; i < pickAttack.Length-1; i++)
        {
            int r = Random.Range(i, pickAttack.Length);
            tempAttack = pickAttack[r];
            pickAttack[r] = pickAttack[i];
            pickAttack[i] = tempAttack;
            break;
        }
    }
   
}
