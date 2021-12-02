using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectiles : StateMachineBehaviour
{
    public float delay;
    public float spriteDelay;
    public float attackDistance;
    public GameObject bossStaple;

    private bool spawn;
    private GameObject player;

    private SpriteRenderer spriteRend;

    void SpawnPin()
    {        
        spawn = false;
        Instantiate(bossStaple, new Vector2(199, 10), Quaternion.identity);                
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpawnPin();              
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
               
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(collision.gameObject);
            Destroy(player);
            StaticVariables.EnemiesKilled += 1;
        }
    }
}
