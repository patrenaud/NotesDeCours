using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Data", fileName = "ScriptableObject", order = 1)]
public class PlayerData : ScriptableObject
{

    [SerializeField]
    private float m_RunSpeed;

    public float RunSpeed
    {
        get { return m_RunSpeed ;}
    }

}
