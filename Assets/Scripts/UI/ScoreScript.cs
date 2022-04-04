using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //Dictates whether Score increases or not
    [SerializeField] private bool scoreIncreasing = false;

    //Dictates how fast the score goes up
    [SerializeField] private float waitInSeconds = 0.5f;

    //The Text variable which displays the score
    private Text scoreText;

    private void Start()
    {
        scoreText = this.GetComponent<Text>();
        scoreText.text = GameController.Instance.score.ToString();
        scoreIncreasing = true;
        StartCoroutine(increaseScore());
    }

    //The Countdown timer to increase score
    IEnumerator increaseScore()
    {
        while (scoreIncreasing)
        {
            GameController.Instance.score++;
            scoreText.text = GameController.Instance.score.ToString();
            yield return new WaitForSeconds(waitInSeconds);
        }
    }

    //Toggles whether score increases or not - if you turned it off, it'll restart coroutine
    public void toggleScoreIncrease(bool tf)
    {
        scoreIncreasing = tf;
        if (scoreIncreasing)
        {
            StartCoroutine(increaseScore());
        }
    }
}
