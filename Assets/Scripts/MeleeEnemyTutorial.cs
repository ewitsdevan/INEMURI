using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyTutorial : MonoBehaviour
{
    public Sprite meleeForward;
    public Sprite meleeSide;
    private SpriteRenderer spriteRend;

    public float idleTime;
    private float meleeSpeed;
    public float walkSpeed;
    public float attackSpeed;
    public float attackDistance;

    private bool turned;
    private bool idle;

    private GameObject player;

    public AudioSource Run;
    public AudioSource Walk;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Dies if shot
        if(collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            StaticVariables.EnemiesKilled += 1;
        }
    }
}
