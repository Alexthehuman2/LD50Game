using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    [SerializeField] private bool scoreIncreasing = false;
    [SerializeField] private float waitInSeconds = 0.5f;
    private int score;
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
            yield return new WaitForSeconds(waitInSeconds);
            score++;
            scoreText.text = score.ToString();
        }
        Debug.Log("Final Score: " + score);
        GameController.Instance.setScore(score);
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
        GameController.Instance.setScore(new_score);
    }
}
