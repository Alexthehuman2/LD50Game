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

    //A simple getter and setter for score
    public int score { get; private set; }

    //The Text variable which displays the score
    private Text scoreText;

    private void Start()
    {
        score = GameController.Instance.score;
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
            score++;
            GameController.Instance.score = score;
            scoreText.text = score.ToString();
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

    //Changes the score entirely including the singleton
    public void changeScoreText(int new_score)
    {
        scoreText.text = new_score.ToString();
        GameController.Instance.score = new_score;
    }
}
