using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 500;

    public int playerAttackDamage = 20;

    bool damage = false;

    public GameObject bossObject;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            health -= playerAttackDamage;
            Debug.Log(health);

            if (health < 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(bossObject);
    }
}
