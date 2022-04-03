using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCompetitor : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().velocity += new Vector2((0.015f + (baseSpeed * GameController.Instance.score) * Time.deltaTime), 0);
    }
}
