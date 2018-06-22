using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D m_RB;
    public float m_Speed = 10f;
	public float m_JumpForce = 250f;

    private Vector2 m_MoveDir = new Vector2();

    public void Update()
    {
        


        if (Input.GetKey(KeyCode.D))
        {
            // va a droite
			m_MoveDir = transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // va a gauche
			m_MoveDir = - transform.right;
        }
        else
        {
            // va nul part
			m_MoveDir = Vector2.zero;
        }

		if(Input.GetKeyDown(KeyCode.W))
		{
			m_RB.AddForce(transform.up * m_JumpForce);
		}
    }


	private void FixedUpdate()
	{
		m_MoveDir *= m_Speed;
		m_MoveDir.y = m_RB.velocity.y;
		m_RB.velocity = m_MoveDir;
	}

}
