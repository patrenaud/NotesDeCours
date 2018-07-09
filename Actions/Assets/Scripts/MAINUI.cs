using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAINUI : MonoBehaviour
{
    public Slider m_LifeBar;

    private void Start()
    {
        // GAMEMANAGER.Instance.m_Player.m_HurtAction += SetLifeValue;

        EventManager.Instance.RegisterEvent(EventID.UpdateHP, SetLifeValue);
        //Debug.Log("Current HP:" + m_LifeBar.value);

    }

    private void SetLifeValue(object a_value)
    {
        m_LifeBar.value = (int)a_value;
    }

    private void OnDestroy()
    {

        // GAMEMANAGER.Instance.m_Player.m_HurtAction -= SetLifeValue;

        EventManager.Instance.UnregisterEvent(EventID.UpdateHP, SetLifeValue);
        //Debug.Log("Current HP:" + m_LifeBar.value);

    }
}
