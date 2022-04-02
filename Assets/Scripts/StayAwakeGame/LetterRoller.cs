using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterRoller : MonoBehaviour
{
    private char letter;
    [SerializeField]private GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        letter = RollLetter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){

        }
        else if (Input.GetKeyDown(KeyCode.B))
        {

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {

        }
        else if (Input.GetKeyDown(KeyCode.F))
        {

        }
        else if (Input.GetKeyDown(KeyCode.G))
        {

        }
        else if (Input.GetKeyDown(KeyCode.H))
        {

        }
        else if (Input.GetKeyDown(KeyCode.I))
        {

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {

        }
        else if (Input.GetKeyDown(KeyCode.K))
        {

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {

        }
        else if (Input.GetKeyDown(KeyCode.M))
        {

        }
        else if (Input.GetKeyDown(KeyCode.N))
        {

        }
        else if (Input.GetKeyDown(KeyCode.O))
        {

        }
        else if (Input.GetKeyDown(KeyCode.P))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

        }
        else if (Input.GetKeyDown(KeyCode.T))
        {

        }
        else if (Input.GetKeyDown(KeyCode.U))
        {

        }
        else if (Input.GetKeyDown(KeyCode.V))
        {

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {

        }
        else if (Input.GetKeyDown(KeyCode.X))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {

        }
    }

    public char RollLetter()
    {
        Random random = new Random();
        // random lowercase letter
        int a = Random.Range(0, 26);
        char ch = (char)('a' + a);

        return ch;
    }
    public void checkKey(char key)
    {
        if (key == letter)
        {
            //increase score
            key = RollLetter();
        }
    }
}
