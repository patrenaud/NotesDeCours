using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public Rigidbody m_Rigidbody;
	public float m_Speed = 10f;
	public float m_TurnSpeed = 5f;

	private Vector3 m_MoveDir = new Vector3();

	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
		{
			m_MoveDir = transform.forward * m_Speed;
		}
		else if(Input.GetKey(KeyCode.S))
		{
			m_MoveDir = -transform.forward * m_Speed;
		}
		else 
		{
			m_MoveDir = Vector3.zero;
		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.up * m_TurnSpeed);
		}
		else if(Input.GetKey(KeyCode.A))
		{
			transform.Rotate(-Vector3.up * m_TurnSpeed);
		}

		
	}

	private void FixedUpdate()
	{
		m_Rigidbody.velocity = m_MoveDir;
	}
}
