using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public int qualityValue;
    public Slider volumeSlider;
    public Dropdown qualityDropdown;

    // Gets default values to apply to UI at start.
    void Start()
    {
        volumeSlider.value = StaticVariables.Volume;

        qualityValue = QualitySettings.GetQualityLevel();
        qualityDropdown.value = qualityValue;
    }

    // Triggered by Slider
    public void VolumeChange()
    {
        StaticVariables.Volume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
    }

    // Triggered by Dropdown
    public void QualityChange()
    {
        qualityValue = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityValue);
    }
}
