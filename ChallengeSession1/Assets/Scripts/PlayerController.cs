using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Vector3 m_MoveDir = new Vector3();
    [SerializeField]
    private float m_Speed = 10.0f;
    [SerializeField]
    private float m_TurnSpeed = 5.0f;
    [SerializeField]
    private Rigidbody m_RigidBody;

    private bool m_ColorSwitch = true;
	
	
	private void Update ()
    {		
        if(Input.GetKey(KeyCode.W))
        {
            m_MoveDir = transform.forward * m_Speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_MoveDir = -transform.forward * m_Speed;
        }
        else
        {
            m_MoveDir = Vector3.zero;
        }

        if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up * m_TurnSpeed);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(-Vector3.up * m_TurnSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchColor();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryManager.Instance.CallInventory();
        }
    }


    private void SwitchColor()
    {
        if(m_ColorSwitch)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            m_ColorSwitch = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            m_ColorSwitch = true;
        }        
    }

    private void FixedUpdate()
    {        
        m_MoveDir.y = m_RigidBody.velocity.y;
        m_RigidBody.velocity = m_MoveDir;        
    }

    private void OnTriggerStay(Collider aOther)
    {
        if(aOther.gameObject.layer == LayerMask.NameToLayer("Cube"))
        {
            if(Input.GetKey(KeyCode.C))
            {
                aOther.gameObject.transform.parent = gameObject.transform;
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                aOther.gameObject.transform.parent = null;
            }
        }
    }

    private void OnTriggerExit(Collider aOther)
    {
        if (aOther.gameObject.layer == LayerMask.NameToLayer("Cube"))
        {
             aOther.gameObject.transform.parent = null;           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Cube"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.cyan;

            collision.gameObject.GetComponent<PlayerController>().enabled = true;
        }
    }
}
