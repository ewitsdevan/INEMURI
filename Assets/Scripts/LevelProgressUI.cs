using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    private Slider progressBar;

    void Start()
    {
        progressBar = GetComponent<Slider>();
    }

    void Update()
    {
        progressBar.value = StaticVariables.Progress;
    }

}
