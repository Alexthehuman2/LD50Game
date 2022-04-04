using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleController : MonoBehaviour
{
    private int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ProcessKey('w');
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ProcessKey('a');
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ProcessKey('s');
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ProcessKey('d');
        }
    }

    void ProcessKey(char key)
    {
        if((key == 'w' && stage == 0) || (key == 'a' && stage == 1) || (key == 's' && stage == 2) || (key == 'd' && stage == 3))
        {
            stage += 1;
            stage %= 4;
            gameObject.transform.GetComponent<Rigidbody2D>().velocity += new Vector2(1, 0);
        }
    }
}
