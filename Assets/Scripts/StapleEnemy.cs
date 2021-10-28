using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StapleEnemy : MonoBehaviour
{
    public float stapleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(stapleSpeed / 100, 0 , 0);
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
