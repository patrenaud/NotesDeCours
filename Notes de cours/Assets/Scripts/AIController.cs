using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BehaviorState
{
    Idle,
    Flee,
    Chase,
    Attack,
    EatRamenSoup,

    Count
}

public class AIController : MonoBehaviour
{
    private BehaviorState m_State;
    public int HP = 100;

    private void Start()
    {
        m_State = BehaviorState.Idle;
    }

    private void Update()
    {
        if (CompareState(BehaviorState.Idle))
        {
            UpdateIdle();
        }
        if (CompareState(BehaviorState.Flee))
        {
            UpdateFlee();
        }
        //etc...
    }


    private void UpdateIdle()
    {
        if (10 < 15)
        {
            m_State = BehaviorState.Attack;
        }
    }
    private void UpdateFlee()
    {

    }
    private void UpdateChase()
    {

    }
    private void UpdateAttack()
    {

    }
    private void UpdateEatRamenSoup()
    {

    }

    private bool CompareState(BehaviorState i_state)
    {
        return i_state == m_State;
    }

	private void ChangeState(BehaviorState i_state)
	{
		m_State = i_state;
		switch(m_State)
		{
			case BehaviorState.EatRamenSoup:
			{
				if(i_state != BehaviorState.EatRamenSoup)
				{
					
				}
				break;
			}
		}
	}

	private void ReceiveDamage(int i_DMG)
	{
		HP -= i_DMG;
		if(HP < 10)
		{
			ChangeState(BehaviorState.EatRamenSoup);
		}
	}
}