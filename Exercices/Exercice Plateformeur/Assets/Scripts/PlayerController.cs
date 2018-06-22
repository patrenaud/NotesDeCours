using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D m_RB;
    public float m_Speed = 10f;
    public float m_BulletSpeed = 20f;
    public float m_JumpForce = 250f;
    public GameObject m_ProjectilePrefab;

    private Vector2 m_MoveDir = new Vector2();



    public void Update()
    {
        Debug.DrawRay(transform.position, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position), Color.red);

        if (Input.GetKey(KeyCode.D))
        {
            // va a droite
            m_MoveDir = transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // va a gauche
            m_MoveDir = -transform.right;
        }
        else
        {
            // va nul part
            m_MoveDir = Vector2.zero;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            m_RB.AddForce(transform.up * m_JumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics2D.Raycast(transform.position, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position), 3f, LayerMask.GetMask("Interractibles")))
            {

                GameObject m_BulletInstance = Instantiate(m_ProjectilePrefab, transform.position, Quaternion.identity);
                Projectile script = m_BulletInstance.GetComponent<Projectile>();
                script.InitSpeed(m_BulletSpeed, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized);
            }
        }
    }


    private void FixedUpdate()
    {
        m_MoveDir *= m_Speed;
        m_MoveDir.y = m_RB.velocity.y;
        m_RB.velocity = m_MoveDir;
    }
}
