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

        // Lorsque UpdateHP se fait appeler, SetlifeValue doit être appelé
        EventManager.Instance.RegisterEvent(EventID.UpdateHP, SetLifeValue);
    }

    private void SetLifeValue(object a_value)
    {
        m_LifeBar.value = (int)a_value;
    }

    private void OnDestroy()
    {
        // GAMEMANAGER.Instance.m_Player.m_HurtAction -= SetLifeValue;

        // Lorsque UpdateHP se fait appeler, SetlifeValue arrête de se faire appelé
        EventManager.Instance.UnregisterEvent(EventID.UpdateHP, SetLifeValue);
    }
}
