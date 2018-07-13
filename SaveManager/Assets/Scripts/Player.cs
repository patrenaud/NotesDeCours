using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int m_CurrentHp;
    public int m_MaxHp;

    private void Awake()
    {
        m_CurrentHp = m_MaxHp;
    }

	private void Start()
	{
		EventManager.Instance.RegisterEvent(EventID.SaveGame, OnSaveGame);
		EventManager.Instance.RegisterEvent(EventID.LoadGame, OnLoadGame);
	}

    private void OnLoadGame(object aArg)
    {
		m_CurrentHp = SaveManager.Instance.CurrentGameData.m_PlayerHp;
		UpdateHp();
    }

    private void OnSaveGame(object aArg)
    {
		SaveManager.Instance.CurrentGameData.m_PlayerHp = m_CurrentHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
			m_CurrentHp -= 10;
            UpdateHp();
        }
    }

    private void UpdateHp()
    {
		float hpPercent = 0f;
		if(m_MaxHp != 0)
		{
			hpPercent = m_CurrentHp / (float)m_MaxHp;
		}
		EventManager.Instance.DispatchEvent(EventID.UpdateHP, hpPercent);
    }
}
