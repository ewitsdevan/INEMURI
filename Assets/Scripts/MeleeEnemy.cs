using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Sprite meleeForward;
    public Sprite meleeSide;
    private SpriteRenderer spriteRend;

    public GameObject player;

    public float idleTime;
    public float speed;

    private bool turned;
    private bool idle;
    private bool playerVisible;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (turned && playerVisible == false && idle == false)
        {
            spriteRend.sprite = meleeSide;
            spriteRend.flipX = false;
            transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        else if (turned == false && playerVisible == false && idle == false)
        {
            spriteRend.sprite = meleeSide;
            spriteRend.flipX = true;
            transform.position = transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }*/
    }

    // Turn trigger
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyBoundry"))
        {
            spriteRend.sprite = meleeForward;
            idle = true;
            StartCoroutine(StartTurn());
        }
    }

    // Waits some time before turning and walking for idle
    IEnumerator StartTurn()
    {
        yield return new WaitForSeconds(idleTime);

        if(turned)
        {
            turned = false;
        }
        else
        {
            turned = true;
        }

        idle = false;
    }
}
