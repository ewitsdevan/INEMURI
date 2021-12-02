using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public bool isMute;
    public int qualityValue;

    public Toggle muteToggle;
    public Dropdown qualityDropdown;

    // Gets default values to apply to UI at start.
    void Start()
    {


        qualityValue = QualitySettings.GetQualityLevel();
        qualityDropdown.value = qualityValue;
    }

    // Triggered by Toggle
    public void MuteChange()
    {
        isMute = muteToggle.isOn;

    }

    // Triggered by Dropdown
    public void QualityChange()
    {
        qualityValue = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityValue);
    }
}
