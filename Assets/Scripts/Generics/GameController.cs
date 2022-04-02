using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public int score { get; private set; }

    public void setScore(int new_score)
    {
        score = new_score;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (this == Instance)
        {
            Debug.Log("Destroying a GameController");
        }
    }
}
