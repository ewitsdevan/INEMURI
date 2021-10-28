using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCupEnemy : MonoBehaviour
{
    public float delay;
    public float spriteDelay;
    public float attackDistance;
    public GameObject pin;

    private bool spawn;
    private GameObject player;

    private SpriteRenderer spriteRend;
    public Sprite idle;
    public Sprite attack;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        StartCoroutine(SpawnDelay());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            if (spawn == true)
            {
                SpawnPin();
            }
        }
        
    }

    //Spawns pin at enemy position
    void SpawnPin()
    {
        spawn = false;
        Instantiate(pin, transform.position, transform.rotation);
        spriteRend.sprite = attack;
        StartCoroutine(SpriteDelay());
        StartCoroutine(SpawnDelay());
    }

    // Delays each spawn
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSecondsRealtime(delay);
        spawn = true;
    }

    IEnumerator SpriteDelay()
    {
        yield return new WaitForSecondsRealtime(spriteDelay);
        spriteRend.sprite = idle;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
