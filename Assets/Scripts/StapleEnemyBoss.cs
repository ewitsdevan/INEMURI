using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StapleEnemyBoss : MonoBehaviour
{
    public float stapleSpeed;
    private Vector3 curPos;
    public float length;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + new Vector3(-1, 0, 0);
        curPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position - new Vector3(stapleSpeed / 100, 0 , 0);

        // Destroys projectile after certain distance
        if (transform.position.x >= curPos.x + length || transform.position.x <= curPos.x - length)
        {
            Destroy(gameObject);
        }
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
