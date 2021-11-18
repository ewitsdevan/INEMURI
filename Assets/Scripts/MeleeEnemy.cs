using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {       
        if (turned && idle == false)
        {
            spriteRend.sprite = meleeSide;
            spriteRend.flipX = true;
            transform.position = transform.position + new Vector3(1, 0, 0) * meleeSpeed * Time.deltaTime;            
        }
        else if (turned == false && idle == false)
        {
            spriteRend.sprite = meleeSide;
            spriteRend.flipX = false;
            transform.position = transform.position - new Vector3(1, 0, 0) * meleeSpeed * Time.deltaTime;           
        }

        if(Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            meleeSpeed = attackSpeed;
            Run.Play(0);
        }
        else
        {
            meleeSpeed = walkSpeed;
            Walk.Play(0);
        }
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Turn trigger
        if (collision.gameObject.CompareTag("EnemyBoundary"))
        {
            spriteRend.sprite = meleeForward;
            idle = true;
            StartCoroutine(StartTurn());
        }

        // Dies if shot
        if(collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            StaticVariables.EnemiesKilled += 1;           
        }
    }

    // Waits some time before turning and walking for idle
    IEnumerator StartTurn()
    {
        yield return new WaitForSecondsRealtime(idleTime);

        if(turned)
        {
            turned = false;
        }
        else if(turned == false)
        {
            turned = true;
        }

        idle = false;
    }
}
