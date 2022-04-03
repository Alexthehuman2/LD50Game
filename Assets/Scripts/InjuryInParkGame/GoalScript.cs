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
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            GameController.Instance.canMove = false;
            if (hasScore)
            {
                score.GetComponent<ScoreScript>().toggleScoreIncrease(false);
            }
            winLossScreen.GetComponent<WinLossUI>().setState(WinLossState.WIN);
            winLossScreen.SetActive(true);
        }
    }
}
