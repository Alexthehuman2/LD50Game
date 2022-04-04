using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Global Score
    public int score;
    //Global Statement whether objects can move
    public bool canMove;



    //Do not add anything beyond this line
    //------------------------------------------------------------------------------------------------------------------------------------------
    //DO NOT TOUCH, Singleton Setup
    public static GameController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}
