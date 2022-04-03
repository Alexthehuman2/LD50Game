using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCompetitor : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    private GameController control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().velocity += new Vector2(1 + (baseSpeed * control.score)/200, 0);
    }
}
