using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private CharacterController player;
    public float speed;
    private Vector3 direction;
    private Vector3 curPos;
    public float length;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>();
        player.GetComponent<CharacterController>();

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
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Moves projectile
        transform.position = transform.position + direction * speed * Time.deltaTime;

        // Destroys projectile after certain distance
        if(transform.position.x >= curPos.x + length || transform.position.x <= curPos.x - length)
        {
            Destroy(gameObject);
        }
    }
}
