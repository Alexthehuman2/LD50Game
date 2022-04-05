using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] private GameObject CreditPanel;
    [SerializeField] private AudioSource buttonPressSFX;

    public void RandomMode()
    {
        buttonPressSFX.Play();
        GameController.Instance.score = 0;
        int randomScene = Random.Range(1, 5);
        Debug.Log(randomScene);
        SceneManager.LoadScene(randomScene);
    }
    public void ReturnToMenu()
    {
        buttonPressSFX.Play();
        SceneManager.LoadScene(0);
    }
    public void exitGame()
    {
        buttonPressSFX.Play();
        Application.Quit();
    }

    public void ShowCredits()
    {
        buttonPressSFX.Play();
        CreditPanel.SetActive(true);
    }

    public void HideCredits()
    {
        buttonPressSFX.Play();
        CreditPanel.SetActive(false);
    }
}
