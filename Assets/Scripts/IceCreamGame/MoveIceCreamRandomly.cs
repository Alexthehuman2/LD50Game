using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIceCreamRandomly : MonoBehaviour
{
    [SerializeField] private float pushForceMulitplier = 2f;
    [SerializeField] private float pushForce = 5f;
    [SerializeField] private Rigidbody2D iceCreamRB;

    [SerializeField] private GameObject iceCreamCone;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject winLossScreen;

    [SerializeField] private bool fallingOff;
    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private IceCreamController control;


    private void Start()
    {
        iceCreamRB = this.GetComponent<Rigidbody2D>();
        control = this.GetComponent<IceCreamController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fallingOff)
        {
            //rigidbody2d add force to an axis randomly between clamped to -1 to 1, multiplied by pushforce
            float randX = Random.Range(-10, 11);
            Vector2 newForce = new Vector2(randX / 10, 0);
            float newPush = Random.Range(-1, 1) > 0 ? pushForceMulitplier * pushForce : -pushForceMulitplier * pushForce;
            iceCreamRB.AddForce(newForce * newPush + control.inputDir);
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

            winLossScreen.SetActive(true);
        }
    }
}
