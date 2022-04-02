using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private bool canMove = false;

    private void Update()
    {
        if (canMove)
        {
            transform.position = new Vector3(transform.position.x-moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
