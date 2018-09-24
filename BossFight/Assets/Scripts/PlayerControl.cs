using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody m_Player;
    public float m_Speed =  10f;
    public float m_RotateSpeed = 5f;
    public float m_JumpForce = 400f;
    public float m_DoubleJumpForce = 400f;
    public bool m_DoubleJump = false;

    private Vector3 m_MoveDir = new Vector3();
    private bool m_CanJump = false;

    void Update()
    {
        // Move conditions
        if (Input.GetKey(KeyCode.W))
        {
            m_MoveDir = transform.forward;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            m_MoveDir = -transform.forward;
        }

        else
        {
            m_MoveDir = Vector3.zero;          
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, m_RotateSpeed);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -m_RotateSpeed);
        }
        m_MoveDir = m_MoveDir * m_Speed;
        m_MoveDir.y = m_Player.velocity.y;
        m_Player.velocity = m_MoveDir;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }


    private void Jump()
    {
        if(m_CanJump)
        {
            m_Player.AddForce(transform.up * m_JumpForce);
        }

        if (m_DoubleJump && !m_CanJump)
        {
            Debug.Log("Player jump");
            m_Player.AddForce(transform.up * m_DoubleJumpForce);
            m_DoubleJump = false;
        }
    }

    private void OnTriggerEnter(Collider aOther)
    {
        if (aOther.tag == ("Ground"))
        {
            m_CanJump = true;
        }
    }
    private void OnTriggerExit(Collider aOther)
    {
        if(aOther.tag == ("Ground"))
        {
            m_CanJump = false;
        }
    }
}
