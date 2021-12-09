using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBehaviour : StateMachineBehaviour
{    
    public string[] pickAttack = { "Attack1", "Attack2", "Attack3"};
    private string tempAttack;

    public int randomAttack;
    private bool shuffle = true;

    private bool melee = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (shuffle)
        {
            Shuffle();
            shuffle = false;
        }

        animator.SetTrigger(pickAttack[Shuffle()]);
        randomAttack++;

        if (randomAttack == pickAttack.Length + 1)
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
        }
      
    }

    public int Shuffle()
    {
        return Random.Range(0, pickAttack.Length);
    }
}

    
