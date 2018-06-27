using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROLLER : MonoBehaviour
{
    [SerializeField]
    private int m_HP = 10;

	public Action<int> m_HurtAction;

    private void Start()
    {
		// Pour que le player dise au manager qu'il est le player actuel
        GAMEMANAGER.Instance.m_Player = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage //
            Damage();
        }
    }

    private void Damage()
    {
        m_HP--;
		if(m_HurtAction != null)
		{
			m_HurtAction(m_HP);
		}
    }

	// FailSafe: le joueur se fait détruire lorsqu'il est mort.
	private void OnDestroy()
	{
		GAMEMANAGER.Instance.m_Player = null;
	}
}
