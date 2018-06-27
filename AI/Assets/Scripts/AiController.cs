using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum BehaviourState
{
    Idle,
    Flee,
    Chase,
    Attack,
    EatRamenSoup,

    Count
}

public class AiController : MonoBehaviour
{
	// for debug pusposes
    private BehaviourState m_State;
	private Vector3 m_InitialePos;
    public int HP = 100;

    // Ceci devrait aller dans le GameManager et non en référence.
    public GameObject m_Player;
    public float m_ChaseThreshold = 10f;
	public NavMeshAgent m_Agent;

    private void Start()
    {
        m_State = BehaviourState.Idle;
		m_InitialePos = transform.position;
    }

    private void Update()
    {

        if (CompareState(BehaviourState.Idle))
        {
            UpdateIdle();
        }
        if (CompareState(BehaviourState.Chase))
        {
            UpdateChase();
        }
        if (CompareState(BehaviourState.Attack))
        {
            UpdateAttack();
        }
        if (CompareState(BehaviourState.Flee))
        {
            UpdateFlee();
        }

        if (CompareState(BehaviourState.EatRamenSoup))
        {
            UpdateEatRamenSoup();
        }
    }

    private void UpdateIdle()
    {
        // On vérifie la distance entre le player et le AI
        if (Vector3.Distance(transform.position, m_Player.transform.position) <= m_ChaseThreshold)
        {
            ChangeState(BehaviourState.Chase);
			
        }
    }

    private void UpdateFlee()
    {
		
    }

    private void UpdateChase()
    {
		m_Agent.SetDestination(m_Player.transform.position);
		
        if (Vector3.Distance(transform.position, m_Player.transform.position) > m_ChaseThreshold)
        {
            ChangeState(BehaviourState.Idle);
        }
    }

    private void UpdateAttack()
    {

    }

    private void UpdateEatRamenSoup()
    {

    }

    private void ReceiveDamage(int i_Damage)
    {
        HP -= i_Damage;
        if (HP < 10)
        {
            ChangeState(BehaviourState.EatRamenSoup);
        }
    }

    private void ChangeState(BehaviourState i_State)
    {
        switch (i_State)
        {

            case BehaviourState.Chase:
                {
                    if (m_State != BehaviourState.Chase)
                    {
                        GetComponent<Renderer>().material.color = Color.red;
						
                    }
                    break;
                }
            case BehaviourState.Idle:
                {
                    if (m_State != BehaviourState.Idle)
                    {
                        GetComponent<Renderer>().material.color = Color.green;
						m_Agent.SetDestination(m_InitialePos);
                    }
                    break;
                }
        }
        m_State = i_State;
    }

    private bool CompareState(BehaviourState i_State)
    {
        return i_State == m_State;
    }
}
