using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossFight : MonoBehaviour
{
    [SerializeField] GameObject music;
    [SerializeField] GameObject progressSlider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            music.SetActive(false);
            progressSlider.SetActive(false);
        }
    }
}
