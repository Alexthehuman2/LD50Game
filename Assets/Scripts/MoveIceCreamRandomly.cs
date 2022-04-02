using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIceCreamRandomly : MonoBehaviour
{

    [SerializeField] private float pushForce = 5f;
    [SerializeField] private Rigidbody2D iceCreamRB;

    [SerializeField] private GameObject iceCreamCone;
    [SerializeField] private GameObject floor;

    [SerializeField] private bool fallingOff;

    private int score = 0;

    private void Start()
    {
        iceCreamRB = this.GetComponent<Rigidbody2D>();
        score = GameController.Instance.score;
        StartCoroutine(increaseScore());
    }

    // Update is called once per frame
    void Update()
    {
        if (!fallingOff)
        {
            //rigidbody2d add force to an axis randomly between clamped to -1 to 1, multiplied by pushforce
            float randX = Random.Range(-10, 10);
            Vector2 newForce = new Vector2(randX / 10, 0);
            iceCreamRB.AddForce(newForce * pushForce);
        }
    }

    IEnumerator increaseScore()
    {
        while (!fallingOff)
        {
            yield return new WaitForSeconds(0.5f);
            score++;
        }
        Debug.Log("Final Score: " + score);
        GameController.Instance.setScore(score);
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
            Debug.Log("Game Over");
            //GameOver, show score, back to menu screen.
        }
    }
}
