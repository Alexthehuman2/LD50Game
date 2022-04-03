using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationState
{
    LEFT = 0,
    RIGHT = 1
}
public class CharacterController : MonoBehaviour
{
    private RotationState state;
    private Vector3 playerRot;
    [SerializeField] private GameObject children;
    [SerializeField] private GameObject scoreScript;
    [SerializeField] private GameObject winLossPanel;
    [SerializeField] private float fallThresholdInDegrees = 75f;
    [SerializeField] private float fallSpeed = 10f;
    [SerializeField] private float fallSpeedCap = 15f;

    private void Start()
    {
        playerRot = children.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        playerRot = children.transform.rotation.eulerAngles;
        if (GameController.Instance.canMove)
        {
            //insert rotation logic here
            Vector3 newRot = new Vector3(0f, 0f, fallSpeed*Time.deltaTime);
            children.transform.rotation = Quaternion.Euler(playerRot+newRot);
        }

        //if the player falls over, this happens
        //POLISH: Make it so it only happens when it touches the ground and rotation is beyond threshold.
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
