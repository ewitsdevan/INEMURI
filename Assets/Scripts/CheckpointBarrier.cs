using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBarrier : MonoBehaviour
{
    public int enemyQuota;
    private SpriteRenderer spriteRend;
    private BoxCollider2D boxCollider;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticVariables.EnemiesKilled >= enemyQuota)
        {
            boxCollider.isTrigger = true;
            spriteRend.enabled = false;
        }
        else
        {
            boxCollider.isTrigger = false;
            spriteRend.enabled = true;
        }
    }
}
