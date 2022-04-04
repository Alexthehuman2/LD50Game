using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterRoller : MonoBehaviour
{
    private char letter;
    [SerializeField] private Text letterText;
    [SerializeField] private SleepSliderScript timer;
    [SerializeField] private Text score;
    [SerializeField] private Animator door;
    // Start is called before the first frame update
    void Start()
    {
        letter = char.ToUpper(RollLetter());
        letterText.text = letter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            checkKey('a');
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            checkKey('b');
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            checkKey('c');
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            checkKey('d');
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            checkKey('e');
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            checkKey('f');
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            checkKey('g');
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            checkKey('h');
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            checkKey('i');
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            checkKey('j');
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            checkKey('k');
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            checkKey('l');
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            checkKey('m');
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            checkKey('n');
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            checkKey('o');
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            checkKey('p');
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            checkKey('q');
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            checkKey('r');
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            checkKey('s');
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            checkKey('t');
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            checkKey('u');
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            checkKey('v');
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            checkKey('w');
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            checkKey('x');
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            checkKey('y');
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            checkKey('z');
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
        if (key == char.ToLower(letter))
        {
            if (door.GetBool("isDoorOpened"))
            {
                timer.lose();
            }
            GameController.Instance.score++;
            score.text = GameController.Instance.score.ToString();
            letter = char.ToUpper(RollLetter());
            letterText.text = letter.ToString();
            timer.IncrementSlider(0.05f);
        }
    }
}
