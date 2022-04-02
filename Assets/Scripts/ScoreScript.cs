using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    [SerializeField] private bool score_increasing = false;
    private int score;
    private Text score_text;

    private void Start()
    {
        score_text = this.GetComponent<Text>();
        score_text.text = GameController.Instance.score.ToString();
        score_increasing = true;
        StartCoroutine(increaseScore());
    }

    IEnumerator increaseScore()
    {
        while (score_increasing)
        {
            yield return new WaitForSeconds(0.5f);
            score++;
            score_text.text = score.ToString();
            Debug.Log("Still Running");
        }
        Debug.Log("Final Score: " + score);
        GameController.Instance.setScore(score);
        StopCoroutine(increaseScore());
    }

    public void toggleScoreIncrease(bool tf)
    {
        score_increasing = tf;
    }

    public void changeScoreText(int new_score)
    {
        score_text.text = new_score.ToString();
    }
}
