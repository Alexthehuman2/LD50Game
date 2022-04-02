using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterRoller : MonoBehaviour
{
    private char letter;
    // Start is called before the first frame update
    void Start()
    {
        letter = RollLetter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public char RollLetter()
    {
        Random random = new Random();
        // random lowercase letter
        int a = Random.Range(0, 26);
        char ch = (char)('a' + a);

        return ch;
    }
}
