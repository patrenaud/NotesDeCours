using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int m_CurrencRoomIndex;
    public int m_PlayerXp;

    public int m_PlayerHp;
    public Vector3 m_PlayerPos;

	public List<Vector3> m_EnemyPos;
	public List<int> m_EnemyHp;
}
