using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskSlam : MonoBehaviour
{
    public GameObject bossObject;
    public AudioSource PunchSFX;
    

    public void KillBoss()
    {
        Destroy(bossObject);
    }

    public void DeskSlamCamera()
    {
        StartCoroutine(LerpFoV(90));
        PunchSFX.Play(0);
    }

    public void ExitDeskSlamCamera()
    {
        StartCoroutine(LerpFoV(100));
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1f);
    }

    IEnumerator LerpFoV(float fov)
    {
        while (Camera.main.fieldOfView != fov)
        { // while the feild of view does not equal the desired value
            if (Camera.main.fieldOfView < fov)
            { // checks if the feild of view is less than fov so it can add up
                Camera.main.fieldOfView += 0.5f;// change this to 0.5f, 0.2f, 0.1f, depending on how fast you want the zoom
            }
            else
            {
                Camera.main.fieldOfView -= 0.5f; // change this to 0.5f, 0.2f, 0.1f
            }
            yield return new WaitForSeconds(0.0f); // so we don't get errors.
        }
    }
}
