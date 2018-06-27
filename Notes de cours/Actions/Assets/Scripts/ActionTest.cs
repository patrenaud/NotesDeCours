using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionTest : MonoBehaviour
{
    public Action m_Action;
	public MonPlayer m_Player;

    private void Update()
    {
		if(m_Action != null)
		{
			m_Action();
		}


		if(m_Player != null)
		{
			m_Player.MyAction();
		}
    }
}
