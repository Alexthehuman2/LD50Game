using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveIceCreamRandomly : MonoBehaviour
{
    [SerializeField] private float pushForceMulitplier = 2f;
    [SerializeField] private float pushForce = 5f;
    [SerializeField] private float scoreInfluenceRate = 1.005f;
    [SerializeField] private Rigidbody2D iceCreamRB;

    [SerializeField] private GameObject iceCreamCone;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject winLossScreen;
    [SerializeField] private GameObject cone;

    [SerializeField] private bool fallingOff;
    [SerializeField] private bool moveable;
    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private IceCreamController control;
    [SerializeField] private Slider timer;


    private void Start()
    {
        iceCreamRB = this.GetComponent<Rigidbody2D>();
        control = this.GetComponent<IceCreamController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fallingOff && moveable)
        {
            //rigidbody2d add force to an axis randomly between clamped to -1 to 1, multiplied by pushforce
            float randX = Random.Range(-10, 11);
            Vector2 newForce = new Vector2(randX / 10, 0);
            float newPush = Random.Range(-1, 1) > 0 ? pushForceMulitplier * pushForce : -pushForceMulitplier * pushForce;
            float actualPush = newPush * Mathf.Pow(scoreInfluenceRate,GameController.Instance.score);
            iceCreamRB.AddForce(newForce * actualPush + control.inputDir);
        }

        if (timer.value <= 0 && !fallingOff)
        {
            timer.GetComponent<GameTimer>().drainTimer(false);
            moveable = false;
            winLossScreen.SetActive(true);
            scoreScript.toggleScoreIncrease(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == iceCreamCone)
        {
            fallingOff = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == floor)
        {
            scoreScript.toggleScoreIncrease(false);
            timer.GetComponent<GameTimer>().drainTimer(false);
            winLossScreen.SetActive(true);
        }
        if (collision.gameObject == cone)
        {
            fallingOff = false;
        }
    }
}
