using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;
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

            if (health <= 0)
            {
                bossObject.GetComponent<Animator>().SetTrigger("BossDead");
                Victory();
            }
        }
    }

    public void Victory()
    {     
        Time.timeScale = 0.8f;
        victoryScreen.SetActive(true);
    }
}
