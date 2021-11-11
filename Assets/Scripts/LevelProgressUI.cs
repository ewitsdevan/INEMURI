using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    private Slider progressBar;

    public float progressSpeed;
    
    void Start()
    {
        progressBar = GetComponent<Slider>();
    }

    void FixedUpdate()
    {
        progressBar.value = Mathf.MoveTowards(progressBar.value, StaticVariables.Progress, progressSpeed * Time.deltaTime);
    }

}
