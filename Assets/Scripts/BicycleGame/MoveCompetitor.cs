using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCompetitor : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    [SerializeField] private float scoreInfluenceRate = 1.005f;
    [SerializeField] private float CPUModifierRange = 10;
    [SerializeField] private float CPUModifierMinRange = 5;

    private float actualSpeed = 0;

    private void Start()
    {
        float cpuModifier = Random.Range(CPUModifierMinRange, CPUModifierRange) / 10;
        actualSpeed = (baseSpeed * cpuModifier) * Mathf.Pow(scoreInfluenceRate, GameController.Instance.score);
        //value = base * interestRate^years
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.canMove)
        {
            // gameObject.transform.GetComponent<Rigidbody2D>().velocity += new Vector2((0.015f + (baseSpeed * GameController.Instance.score / 10) * Time.deltaTime), 0);
            gameObject.transform.GetComponent<Rigidbody2D>().velocity += new Vector2(actualSpeed * Time.deltaTime, 0);
        }
    }
}
