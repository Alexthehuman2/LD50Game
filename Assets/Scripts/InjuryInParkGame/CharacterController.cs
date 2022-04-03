using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    private Vector3 playerRot;
    private bool rotatingLeft = true;
    private float currentZ = 0;
    [SerializeField] private GameObject children;
    [SerializeField] private GameObject scoreScript;
    [SerializeField] private GameObject winLossPanel;
    [SerializeField] private float fallThresholdInDegrees = 75f;
    [SerializeField] private float fallSpeed = 10f;
    [SerializeField] private float fallSpeedCap = 15f;
    [SerializeField] private float playerRotInfluence = 12.5f;

    private void Start()
    {
        playerRot = children.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        //gets the player rotation as variable
        playerRot = children.transform.rotation.eulerAngles;

        //Decides rotation state whether to increase left or right
        rotatingLeft = (playerRot.z >= 0);
        Debug.Log("Rotating Left? : " + rotatingLeft);
        
        if (GameController.Instance.canMove)
        {
            //Rotation Polish: LERP the rot speed to cap
            float rotZ = rotatingLeft == true ? fallSpeed : -fallSpeed; //this get influenced by player input
            currentZ += rotZ;
            if (currentZ > fallSpeedCap)
            {
                currentZ = fallSpeedCap;
            }
            else if (currentZ < -fallSpeedCap)
            {
                currentZ = -fallSpeedCap;
            }

            float threshold = rotatingLeft == true ? fallThresholdInDegrees : -fallThresholdInDegrees;

            //player input
            if (Input.GetKey(KeyCode.D))
            {
                currentZ -= playerRotInfluence;
                Debug.Log("Pressing D, current RotZ: "+rotZ);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                currentZ += playerRotInfluence;
                Debug.Log("Pressing A, current RotZ: " + rotZ);
            }
            Vector3 newRot = new Vector3(0f, 0f, currentZ*Time.deltaTime);

            children.transform.rotation = Quaternion.Euler(playerRot+newRot); //endgoal
            //A value that gets added to the rotation, the value is lerped to an influenced value by player holding down key, and the update loop generating rotation
        }
        playerRot = children.transform.rotation.eulerAngles;

        //if the player falls over, this happens
        //POLISH: Make it so it only happens when it touches the ground and rotation is beyond threshold.
        // -1, 359
        if ((playerRot.z > fallThresholdInDegrees || playerRot.z < -fallThresholdInDegrees) && GameController.Instance.canMove)
        {
            Debug.Log("This is running");
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true; //freezes player
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameController.Instance.canMove = false; //freezes the map and everything else.
            scoreScript.GetComponent<ScoreScript>().toggleScoreIncrease(false);
            winLossPanel.GetComponent<WinLossUI>().setState(WinLossState.LOSS);
            winLossPanel.SetActive(true);
        }
    }

}
