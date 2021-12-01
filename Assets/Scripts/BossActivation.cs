using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    [SerializeField] GameObject bossObject;
    [SerializeField] GameObject music;
    [SerializeField] GameObject BossMusic;
    [SerializeField] GameObject bossBackground;

    public float speed;
    public float newFoV;

    public void Start()
    {
        newFoV = Camera.main.fieldOfView;
    }

    void FixedUpdate()
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, newFoV, 1 / speed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is here");
            bossObject.SetActive(true);
            newFoV = 125f;
            music.SetActive(false);
            BossMusic.SetActive(true);
            bossBackground.SetActive(true);
        }
    }
}
