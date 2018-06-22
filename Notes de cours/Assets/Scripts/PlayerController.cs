using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Le RequireComponent ajoute le component sur l'objet s'il n'y est pas à l'ajout du script.
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Variables Editors
    [SerializeField]
    private PlayerData m_Data;
    [SerializeField]
    private Transform m_RaycastParent;

    private float m_RotateSpeed = 20f;
    private float m_RunSpeed = 10f;
    private float m_RunAcceleration = 5f;
    private float m_JumpForce = 650f;
    private float m_FakeGravity = 20f;


    // Variables privées de direction
    private float m_CurrentSpeed;
    private float m_InputX = 0f;
    private float m_InputZ = 0f;
    private bool m_IsGrounded = true;

    // Vecteurs
    private Vector3 m_LookRotation = new Vector3();
    private Vector3 m_MoveDir = new Vector3();

    // Components
    private Rigidbody m_Rigidbody;


    private void Awake()
    {
        // On initialise les variables
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        m_RunSpeed = m_Data.RunSpeed;
    }

    private void FixedUpdate()
    {
        // Modifier la vélocité
        m_MoveDir.y = m_Rigidbody.velocity.y;
        if (m_Rigidbody.velocity.y != 0f)
        {
            m_MoveDir.y -= m_FakeGravity * Time.fixedDeltaTime;
        }
        m_Rigidbody.velocity = m_MoveDir;
    }

    private void Update()
    {
        // Valider les Inputs utilisateur
        if (CheckInputAxis())
        {
            // Do stuff
            if (m_CurrentSpeed < m_RunSpeed)
            {
                m_CurrentSpeed += m_RunSpeed * m_RunAcceleration * Time.deltaTime;
            }
            m_MoveDir = transform.forward * m_CurrentSpeed;
        }
        else
        {
            // Do other stuff
            m_MoveDir = Vector3.zero;
            m_CurrentSpeed = 0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        UpdateRotation();
        RaycastGround();
    }

    private void Jump()
    {
        // Ajoute une force en y au joueur
        if (m_IsGrounded)
        {
            m_IsGrounded = false;
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0f, m_Rigidbody.velocity.z);

            m_Rigidbody.AddForce(transform.up * m_JumpForce);
        }
    }

    private void UpdateRotation()
    {
        // Updater la rotation
        m_LookRotation.x = m_InputX;
        m_LookRotation.z = m_InputZ;
        m_LookRotation *= m_RunSpeed; // FailSafe

        if (CheckInputAxis())
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(m_LookRotation), m_RotateSpeed * Time.deltaTime);
        }
    }

    public void RaycastGround()
    {
        if (m_Rigidbody.velocity.y < 0f)
        {
            // Utiliser 9 fois le Raycast au sol
            for (int i = 0; i < m_RaycastParent.childCount; i++)
            {
                Debug.DrawRay(m_RaycastParent.GetChild(i).transform.position, -transform.up);
                if (Physics.Raycast(m_RaycastParent.GetChild(i).transform.position, -transform.up, 0.6f))
                {
                    m_IsGrounded = true;
                    return;
                }
            }
        }
    }

    private bool CheckInputAxis()
    {
        // On vérifi les inputs et on retoure vrai s'il y a un input
        m_InputX = Input.GetAxis("Horizontal");
        m_InputZ = Input.GetAxis("Vertical");
        return m_InputX != 0f || m_InputZ != 0f; ;
    }
}
