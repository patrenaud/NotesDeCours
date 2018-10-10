using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float m_RunSpeed = 10f;
    public float m_RunAcceleration = 5f;
    public float m_TurnSpeed = 10f;
    public float m_JumpForce = 650f;
    public float m_FakeGravity = 20f;
    public float m_MaxGroundAngle = 45f;
    public float m_CharacterHeight = 1f;
    public float m_HeightPadding = 0.5f;
    public LayerMask m_Layer;

    public bool m_ActiveDebug = true;

    private Rigidbody m_RigidBody;
    private float m_CurrentSpeed = 0f;
    private Vector2 m_Input = new Vector2();
    private float m_RotationAngle;
    private float m_GroundAngle;

    private Quaternion m_TargetRotation = new Quaternion();
    private Transform m_CameraPos;

    private Vector3 m_Forward = new Vector3();
    private RaycastHit m_HitInfo;
    private bool m_IsGrounded = true;
    private Vector3 m_MoveDir = new Vector3();


    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Start ()
    {
        m_CameraPos = Camera.main.transform;
	}	

	private void Update ()
    {
        GetInput();
        CalculateDirection();
        RaycastGround();
        CalculateGroundAngle();
        CalculateForward();

        if(m_ActiveDebug)
        {
            DrawDebugLines();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    private void FixedUpdate()
    {
        if(m_Input != Vector2.zero)
        {
            Rotate();
            SetSpeed();
        }
        else
        {
            ResetSpeed();
        }

        m_MoveDir = m_Forward * m_CurrentSpeed;
        m_MoveDir.y = m_RigidBody.velocity.y;

        if(m_RigidBody.velocity.y != 0)
        {
            m_MoveDir.y -= m_FakeGravity * Time.fixedDeltaTime;
        }

        m_RigidBody.velocity = m_MoveDir;
    }

    private void GetInput()
    {
        m_Input.x = Input.GetAxis("Horizontal");
        m_Input.y = Input.GetAxis("Vertical");
    }

    private void CalculateDirection()
    {
        // Calcul l'angle en radiant selon l'input
        m_RotationAngle = Mathf.Atan2(m_Input.x, m_Input.y);
        // Transférer l'angle en degrées
        m_RotationAngle *= Mathf.Rad2Deg;

        // Rotation relative à la caméra
        m_RotationAngle += m_CameraPos.localEulerAngles.y;
    }

    private void CalculateForward()
    {
        if(m_IsGrounded)
        {
            // Retourne le vector forward en considérant la pente du GroundAngle. Le forward sera parallèle
            m_Forward = Vector3.Cross(transform.right, m_HitInfo.normal);
        }
        else
        {
            m_Forward = transform.forward;
        }
    }

    private void CalculateGroundAngle()
    {
        if(m_IsGrounded)
        {
            // Angle du sol en utilisant la normale et notre forward
            m_GroundAngle = Vector3.Angle(m_HitInfo.normal, transform.forward);
        }
        else
        {
            m_GroundAngle = 90f;
        }
    }

    private void RaycastGround() // Pour le 9 raycast on aura besoin d'une autre fonction ***********
    {
        // Vector3.down est good si on ne change pas la gravité du jeu.
        if(Physics.Raycast(transform.position, Vector3.down, out m_HitInfo, m_CharacterHeight + m_HeightPadding, m_Layer))
        {
            m_IsGrounded = true;
        }
        else
        {
            m_IsGrounded = false;
        }
    }

    private void Rotate()
    {
        // Convertir les euleurAngles en Quaternions
        m_TargetRotation = Quaternion.Euler(0f, m_RotationAngle, 0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, m_TargetRotation, m_TurnSpeed * Time.fixedDeltaTime);
    }

    private void SetSpeed()
    {
        if(m_GroundAngle < m_MaxGroundAngle + 90f)
        {
            if(m_CurrentSpeed < m_RunSpeed)
            {
                // Fixed delta time car on ne veut pas les secondes. On veut seulement que ce soit constant. Sinon, des spikes d'accélération peuvent apparaître.
                m_CurrentSpeed += m_RunSpeed * (m_RunAcceleration * Time.fixedDeltaTime); 
            } 
        }
        else
        {
            ResetSpeed();
        }
    }

    private void Jump()
    {
        if(m_IsGrounded)
        {
            m_IsGrounded = false;
            m_RigidBody.velocity = Vector3.zero;
            m_RigidBody.AddForce(transform.up * m_JumpForce);
        }
    }

    private void ResetSpeed()
    {
        m_CurrentSpeed = 0f;
    }

    private void DrawDebugLines()
    {
        // Vector Forward
        Debug.DrawLine(transform.position, transform.position + m_Forward * m_HeightPadding * 2, Color.blue);
        // Vector Normale
        Debug.DrawLine(transform.position, transform.position - Vector3.up *(m_CharacterHeight + m_HeightPadding), Color.red);
    }
}

