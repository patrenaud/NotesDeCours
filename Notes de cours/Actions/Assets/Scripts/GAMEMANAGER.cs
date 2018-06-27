using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
	// Ceci est pour le singleton
    private static GAMEMANAGER m_Instance;
    public static GAMEMANAGER Instance
    {
        get { return m_Instance; }
    }
	// On doit référer le player
	public PLAYERCONTROLLER m_Player;

    private void Awake()
    {
        if (m_Instance != null)
        {
            Destroy(this);
        }
        else
        {
            m_Instance = this;
        }

		DontDestroyOnLoad(gameObject);
    }
}
