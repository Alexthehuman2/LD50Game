using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public void RandomMode()
    {
        GameController.Instance.score = 0;
        int randomScene = Random.Range(1, 4);
        Debug.Log(randomScene);
        SceneManager.LoadScene(randomScene);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
