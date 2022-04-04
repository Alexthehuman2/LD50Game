using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Enum for Win/Loss State
public enum WinLossState
{
    LOSS = 0,
    WIN = 1
}

public class WinLossUI : MonoBehaviour
{
    public WinLossState state { get; private set; }

    [SerializeField] private GameObject WinText;
    [SerializeField] private GameObject LoseText;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject ReturnToTitleButton;
    [SerializeField] private GameObject RestartGameButton;
    [SerializeField] private GameObject NextGameInText;
    [SerializeField] private GameObject TimerUntilNextGame;
    [SerializeField] private ScoreScript inGameScore;

    private void Start()
    {

        this.gameObject.SetActive(false);
    }

    //A Switch Case that displays the correct info based on state.
    private void OnEnable()
    {
        switch (state)
        {
            case WinLossState.LOSS:
                WinText.SetActive(false);
                LoseText.SetActive(true);
                scoreText.SetActive(true);
                score.GetComponent<Text>().text = GameController.Instance.score.ToString();
                score.SetActive(true);
                ReturnToTitleButton.SetActive(true);
                RestartGameButton.SetActive(true);
                NextGameInText.SetActive(false);
                TimerUntilNextGame.SetActive(false);
                return;
            case WinLossState.WIN:
                WinText.SetActive(true);
                LoseText.SetActive(false);
                scoreText.SetActive(false);
                score.SetActive(false);
                ReturnToTitleButton.SetActive(false);
                RestartGameButton.SetActive(false);
                NextGameInText.SetActive(true);
                TimerUntilNextGame.SetActive(true);
                return;
            default:
                Debug.Log("WinLoss UI broken state");
                return;
        }
    }

    //Sets whether the Win Loss Panel display win or lose information under the same game object
    public void setState(WinLossState winLoss)
    {
        state = winLoss;
    }
    public void ReturnToTitle()
    {
        //scenemanagement.loadscene...
    }

    public void RestartGame()
    {
        //scenemanagement.loadscene...
    }
}
