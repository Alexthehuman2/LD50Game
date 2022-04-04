using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepSliderScript : MonoBehaviour
{
    public Slider sleepSlider;
    public float drainRate;
    public float scalingFactor;
    [SerializeField] private bool scalingDrainRate = true;
    [SerializeField] private WinLossUI winloss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sleepSlider.value -= Time.deltaTime * drainRate;
        if(sleepSlider.value <= 0)
        {
            winloss.setState(WinLossState.LOSS);
            winloss.gameObject.SetActive(true);
        }
        if (scalingDrainRate)
        {
            drainRate *= scalingFactor;
        }
    }

    public void IncrementSlider(float amount)
    {
        sleepSlider.value += amount;
    }
}
