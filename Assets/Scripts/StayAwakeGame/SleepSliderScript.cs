using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepSliderScript : MonoBehaviour
{
    [SerializeField] private Slider sleepSlider;
    [SerializeField] private float drainRate;
    [SerializeField] private float scalingFactor;
    [SerializeField] private float scoreInfluenceRate = 1.005f;
    [SerializeField] private bool scalingDrainRate = true;
    [SerializeField] private WinLossUI winloss;
    [SerializeField] private float timeRemaining;
    [SerializeField] private GameObject LetterOnScreen;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject Door;
    [SerializeField] private Text timerText;
    [SerializeField] private AudioSource doorOpening;
    [SerializeField] private AudioSource doorClosing;
    private Animator doorAnim;


    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.canMove = true;
        doorAnim = Door.GetComponent<Animator>();
        StartCoroutine(ParentAppearing());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.canMove)
        {
            sleepSlider.value -= Time.deltaTime * (drainRate * Mathf.Pow(scoreInfluenceRate, GameController.Instance.score));
        }
        
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
        if (winloss.gameObject.activeSelf == false)
        {
            timerText.text = time;
        }


        if (timeRemaining <= 0)
        {
            GameController.Instance.canMove = false;
            StopAllCoroutines();
            score.GetComponent<ScoreScript>().toggleScoreIncrease(false);
            timerText.gameObject.SetActive(false);
            LetterOnScreen.SetActive(false);
            winloss.setState(WinLossState.WIN);
            winloss.gameObject.SetActive(true);
        }

        if (sleepSlider.value <= 0)
        {
            GameController.Instance.canMove = false;
            StopAllCoroutines();
            score.GetComponent<ScoreScript>().toggleScoreIncrease(false);
            timerText.gameObject.SetActive(false);
            LetterOnScreen.SetActive(false);
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

    IEnumerator ParentAppearing()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        doorOpening.Play();
        doorAnim.SetBool("isDoorOpened", true);
        yield return new WaitForSeconds(5);
        doorClosing.Play();
        doorAnim.SetBool("isDoorOpened", false);
        StartCoroutine(ParentAppearing());
    }

    public void IncrementSlider(float amount)
    {
        sleepSlider.value += amount;
    }
    public void lose()
    {
        GameController.Instance.canMove = false;
        StopAllCoroutines();
        score.GetComponent<ScoreScript>().toggleScoreIncrease(false);
        timerText.gameObject.SetActive(false);
        LetterOnScreen.SetActive(false);
        winloss.setState(WinLossState.LOSS);
        winloss.gameObject.SetActive(true);
    }
}
