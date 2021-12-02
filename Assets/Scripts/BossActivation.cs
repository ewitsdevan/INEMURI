using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    [SerializeField] GameObject bossObject;
    [SerializeField] GameObject music;
    [SerializeField] GameObject BossMusic;
    [SerializeField] GameObject bossBackground;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is here");
            bossObject.SetActive(true);           
            music.SetActive(false);
            BossMusic.SetActive(true);
            bossBackground.SetActive(true);
            StartCoroutine(LerpFoV(100));
            GameObject.Find("Main Camera").transform.position = new Vector3(181,20,-17.5f);           
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
