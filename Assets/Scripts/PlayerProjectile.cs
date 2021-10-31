using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private PlayerController player;
    public float projectileSpeed;
    private Vector3 direction;
    private Vector3 curPos;
    public float length;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); ;

        curPos = transform.position;

        // Checks what direction player is facing
        if(player.horizAxis > 0)
        {
            direction = new Vector3(1, 0, 0);
        }
        else if (player.horizAxis < 0)
        {
            direction = new Vector3(-1, 0, 0);
        }
        else
        {
            
            if (player.lastAxis < 0)
            {
                direction = new Vector3(-1, 0, 0);
            }
            else
            {
                direction = new Vector3(1, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Moves projectile
        transform.position = transform.position + direction * projectileSpeed * Time.deltaTime;

        // Destroys projectile after certain distance
        if(transform.position.x >= curPos.x + length || transform.position.x <= curPos.x - length)
        {
            Destroy(gameObject);
        }
    }
}
