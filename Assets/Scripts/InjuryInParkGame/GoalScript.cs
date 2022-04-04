using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField] private GameObject winLossScreen;
    [SerializeField] private GameObject score;
    [SerializeField] private bool hasScore = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject == player)
        {
            winLossScreen.GetComponent<WinLossUI>().setState(WinLossState.WIN);
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameController.Instance.canMove = false;
            if (hasScore)
            {
                score.GetComponent<ScoreScript>().toggleScoreIncrease(false);
            }
            
            winLossScreen.SetActive(true);
        }
        else if (collision.gameObject.tag == "Competitors")
        {
            winLossScreen.GetComponent<WinLossUI>().setState(WinLossState.LOSS);
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameController.Instance.canMove = false;
            if (hasScore)
            {
                score.GetComponent<ScoreScript>().toggleScoreIncrease(false);
            }
            winLossScreen.SetActive(true);
        }
    }
}
