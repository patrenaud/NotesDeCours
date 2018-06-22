using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : MonoBehaviour
{

    public Rigidbody2D m_RigidBody;
    public float m_Speed;

    private float m_CurrentTime = 0;
    private float m_Time = 3f;
	private Vector2 m_Dir = new Vector2();

    public void InitSpeed(float aSpeed, Vector2 aDirection)
    {
        m_Speed = aSpeed;
		m_Dir = aDirection;
    }

    private void FixedUpdate()
    {        
        m_RigidBody.velocity = m_Dir * m_Speed;
        m_CurrentTime += Time.deltaTime;
        if (m_CurrentTime >= m_Time)
        {
            Destroy(gameObject);
        }
    }

}
