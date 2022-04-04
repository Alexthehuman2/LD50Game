using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepSliderScript : MonoBehaviour
{
    [SerializeField] private Slider sleepSlider;
    [SerializeField] private float drainRate;
    [SerializeField] private float scalingFactor;
    [SerializeField] private bool scalingDrainRate = true;
    [SerializeField] private WinLossUI winloss;
    [SerializeField] private float timeRemaining;
    [SerializeField] private Text timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sleepSlider.value -= Time.deltaTime * drainRate;
        timeRemaining -= Time.deltaTime;
        float inverseTime = 20 - timeRemaining;
        float displayTime = inverseTime * 60 * 12; 
        int hours = Mathf.FloorToInt(displayTime / 60 / 60);
        int minutes = Mathf.FloorToInt(displayTime / 60 % 60);

        hours += 10;
        if (hours > 12)
        {
            hours -= 12;
        }

        string time = hours.ToString() + ":";

        if (minutes < 10)
        {
            time += "0";
        }
        time += minutes.ToString();
        if(winloss.gameObject.activeSelf == false)
        {
            timerText.text = time;
        }
        

        if (timeRemaining <= 0)
        {
            winloss.setState(WinLossState.WIN);
            winloss.gameObject.SetActive(true);
        }

        if (sleepSlider.value <= 0)
        {
            winloss.setState(WinLossState.LOSS);
            winloss.gameObject.SetActive(true);
        }
        /*
        if (scalingDrainRate)
        {
            drainRate *= scalingFactor;
        }
        */
    }

    public void IncrementSlider(float amount)
    {
        sleepSlider.value += amount;
    }
}
