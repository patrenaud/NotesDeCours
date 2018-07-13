using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	[SerializeField]
	private Slider m_HpSlider;

    private void Start()
    {
		EventManager.Instance.RegisterEvent(EventID.UpdateHP, OnUpdateHP);
    }

    private void OnUpdateHP(object aArg)
    {
		m_HpSlider.value = (float)aArg;
    }

}
