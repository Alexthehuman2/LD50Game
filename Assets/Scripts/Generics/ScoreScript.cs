using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    [SerializeField] private bool scoreIncreasing = false;
    private int score;
    private Text scoreText;

    private void Start()
    {
        scoreText = this.GetComponent<Text>();
        scoreText.text = GameController.Instance.score.ToString();
        scoreIncreasing = true;
        StartCoroutine(increaseScore());
    }

    IEnumerator increaseScore()
    {
        while (scoreIncreasing)
        {
            yield return new WaitForSeconds(0.5f);
            score++;
            scoreText.text = score.ToString();
        }
        Debug.Log("Final Score: " + score);
        GameController.Instance.setScore(score);
    }

    public void toggleScoreIncrease(bool tf)
    {
        scoreIncreasing = tf;
    }

    public void changeScoreText(int new_score)
    {
        scoreText.text = new_score.ToString();
    }
}
