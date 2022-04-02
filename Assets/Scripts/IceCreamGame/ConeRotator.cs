using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationStates
{
    STARTSTATE = 0,
    ROTATELEFT = 1,
    ROTATERIGHT = 2
}
public class ConeRotator : MonoBehaviour
{
    private float rotx = 0;
    private RotationStates states;

    private void Start()
    {
        
    }

    void Update()
    {
        switch (states)
        {
            case RotationStates.STARTSTATE:
                return;
            case RotationStates.ROTATELEFT:
                return;
            case RotationStates.ROTATERIGHT:
                return;
            default:
                return;
        }
        //this.transform.RotateAround(this.transform,Vector3.forward,Mathf.Lerp(0,))
    }
}
