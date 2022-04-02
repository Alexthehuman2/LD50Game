﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Slider sleepSlider;
    public float drainRate;
    public float scalingFactor;
    [SerializeField] private bool scalingDrainRate = true;
    [SerializeField] private GameObject winLossPanel;
    private WinLossUI winLossScript;

    // Start is called before the first frame update
    void Start()
    {
        sleepSlider = this.GetComponent<Slider>();
        winLossScript = winLossPanel.GetComponent<WinLossUI>();
    }

    // Update is called once per frame
    void Update()
    {
        sleepSlider.value -= Time.deltaTime * drainRate;
        if (scalingDrainRate)
        {
            drainRate *= scalingFactor;
        }
    }

    public void checkTimer()
    {
        if (sleepSlider.value <= 0)
        {
            winLossScript.setState(WinLossState.WIN);
        }
    }
}
