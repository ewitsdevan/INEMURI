using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] GameObject bossHealth;
    [SerializeField] GameObject bossMusic;
    [SerializeField] GameObject exitBoss;
    [SerializeField] GameObject barrierBoss;

    public Slider bossHealthBar;

    public int curHealth = 500;

    public int playerAttackDamage = 20;

    bool damage = false;

    public GameObject bossObject;

    public AudioSource damageBoss;
    public AudioSource victoryBoss;

    public float timeToColor;
    SpriteRenderer sr;
    Color defaultColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            curHealth -= playerAttackDamage;
            bossHealthBar.value -= playerAttackDamage;
            damageBoss.Play(0);
            StartCoroutine("SwitchColor");         

            if (curHealth <= 0)
            {
                bossObject.GetComponent<Animator>().SetTrigger("BossDead");
                bossHealth.SetActive(false);
                exitBoss.SetActive(true);
                bossMusic.SetActive(false);
                barrierBoss.SetActive(false);
                victoryBoss.Play(0);
            }
        }        
    }

    IEnumerator SwitchColor()
    {
        sr.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(timeToColor);
        sr.color = defaultColor;       
    }

    IEnumerator WaitBeforeCutscene(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
    }
}
