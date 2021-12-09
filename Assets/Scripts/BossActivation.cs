using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    [SerializeField] GameObject bossObject;
    [SerializeField] GameObject BossMusic;
    [SerializeField] GameObject bossBackground;
    [SerializeField] GameObject bossHealth;
    [SerializeField] GameObject barrierBoss;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            bossObject.SetActive(true);                      
            BossMusic.SetActive(true);
            bossBackground.SetActive(true);
            bossHealth.SetActive(true);
            barrierBoss.SetActive(true);
            StartCoroutine(LerpFoV(100));
            Camera.main.GetComponent<FollowPlayer>().enabled = false;
            Camera.main.transform.position = new Vector3(190,25,-14);           
        }   
    }

    IEnumerator LerpFoV(float fov)
    {
        while (Camera.main.fieldOfView != fov)
        { // while the feild of view does not equal the desired value
            if (Camera.main.fieldOfView < fov)
            { // checks if the feild of view is less than fov so it can add up
                Camera.main.fieldOfView += 0.1f;// change this to 0.5f, 0.2f, 0.1f, depending on how fast you want the zoom
            }
            else
            {
                Camera.main.fieldOfView -= 0.1f; // change this to 0.5f, 0.2f, 0.1f
            }
            yield return new WaitForSeconds(0.0f); // so we don't get errors.
        }
    }
}
