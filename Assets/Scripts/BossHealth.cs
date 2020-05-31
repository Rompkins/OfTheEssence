using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider slider;
    public Enemy enemy;

    private void Start()
    {
        slider.maxValue = 100;
    }
    private void Update()
    {
        slider.value = enemy.health;

    }
}
