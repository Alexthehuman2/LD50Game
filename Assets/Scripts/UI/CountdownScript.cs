﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private int countDownValue = 5;

    private void Start()
    {
        this.GetComponent<Text>().text = countDownValue.ToString();
        StartCoroutine(countdown());
    }
    IEnumerator countdown()
    {
        while (countDownValue > 0)
        {
            yield return new WaitForSeconds(1f);
            countDownValue--;
            this.GetComponent<Text>().text = countDownValue.ToString();
        }
        SceneManager.LoadScene(1);
    }
}