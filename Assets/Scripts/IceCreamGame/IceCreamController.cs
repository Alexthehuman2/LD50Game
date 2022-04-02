using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D iceCreamRB2D;
    [SerializeField] private float inputForce = 1f;
    public Vector2 inputDir { get; private set; }

    private void Start()
    {
        iceCreamRB2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.1f) { inputDir = new Vector2 (inputForce,0); }
        if (Input.GetAxis("Horizontal") < -0.1f) { inputDir = new Vector2(-inputForce, 0); }
    }
}
