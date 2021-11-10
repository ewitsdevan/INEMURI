using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource buttonSFX;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    public void HoverSound()
    {
        buttonSFX.PlayOneShot(hoverFX);
    }

    public void ClickSound()
    {
        buttonSFX.PlayOneShot(clickFX);
    }
}
