using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonPlayer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActionTest test = GameObject.FindObjectOfType<ActionTest>();
            test.m_Action += MyAction;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.AddComponent<ActionTest>();
        }
    }

    public void MyAction()
    {
        Debug.Log("Way too many Logs. Please collapse");
    }

    private void OnDestroy()
    {
        ActionTest test = GameObject.FindObjectOfType<ActionTest>();
        test.m_Action -= MyAction;
    }
}
