using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleManager : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;
    public SpriteRenderer head;

    public Sprite angryFace;
    public Sprite idleFace;
    public Sprite damageFace;
    public Sprite finalFace;

    public Collider2D torsoCollider;
    public Collider2D leftHandCollider;

    private bool idle;
    private bool canDamage;
    private int attackPhase;

    public int health;
    public float idleDelay;
    public float attackDelay;
    public float damageDelay;

    // Start is called before the first frame update
    void Start()
    {
        idle = true;
        canDamage = false;
        leftHandCollider.enabled = false;

        ChangePhase();
    }

    // Update is called once per frame
    void ChangePhase()
    {
        if(idle == false)
        {
            Attack();
        }
        else
        {
            Idle();
        }
    }

    void Expressions(Sprite faceExpression)
    {
        head.sprite = faceExpression;
    }

    void Attack()
    {
        if(attackPhase == 1)
        {
            leftHandCollider.enabled = true;
        }
        else if (attackPhase == 2)
        {

        }
        else if (attackPhase == 3)
        {

        }
    }

    void Idle()
    {
        if(attackPhase == 0)
        {
            Expressions(idleFace);
            StartCoroutine(IdleDelay());
        }
        else
        {
            torsoCollider.enabled = true;
            StartCoroutine(DamageDelay());
        }
        
    }

    IEnumerator IdleDelay()
    {
        return new WaitForSecondsRealtime(idleDelay);
        idle = false;
        attackPhase++;
        ChangePhase();
    }

    IEnumerator AttackDelay()
    {
        return new WaitForSecondsRealtime(attackDelay);
    }

    IEnumerator DamageDelay()
    {
        return new WaitForSecondsRealtime(damageDelay);
        torsoCollider.enabled = false;
        idle = false;
    }
}
