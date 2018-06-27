using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAINUI : MonoBehaviour
{
    public Slider m_LifeBar;

    private void Start()
    {
        if (GAMEMANAGER.Instance.m_Player != null)
        {
            GAMEMANAGER.Instance.m_Player.m_HurtAction += SetLifeValue;
        }
    }

    private void SetLifeValue(int a_value)
    {
        m_LifeBar.value = a_value;
    }

    private void OnDestroy()
    {
        if (GAMEMANAGER.Instance.m_Player != null)
        {
            GAMEMANAGER.Instance.m_Player.m_HurtAction -= SetLifeValue;
        }
    }
}
