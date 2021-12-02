using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] GameObject healthObject;

    void Update()
    {
        slider.value = healthObject.GetComponent<BossHealth>().curHealth;
    }
}
