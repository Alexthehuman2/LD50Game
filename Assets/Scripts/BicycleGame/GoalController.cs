using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private WinLossUI winloss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            winloss.setState(WinLossState.WIN);
            winloss.gameObject.SetActive(true);
        }
        else
        {
            winloss.setState(WinLossState.LOSS);
            winloss.gameObject.SetActive(true);
        }
    }
}
