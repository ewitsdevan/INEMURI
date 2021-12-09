using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectiles : StateMachineBehaviour
{
    public float delay;
    public float spriteDelay;
    public float attackDistance;
    public GameObject bossStaple;

    private GameObject player;

    void SpawnStaple()
    {        
        Instantiate(bossStaple, new Vector2(199, 10), Quaternion.identity);                
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpawnStaple();              
    }
}
