using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour 
{
	// la variable se track moins bien en utilisant cette méthode pour le singleton
	public static EventManager Instance { get; private set ;}

	private Dictionary<EventID, Action<object>> m_EventDict;

	private void Awake()
	{
		if(Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
		DontDestroyOnLoad(this);
		m_EventDict = new Dictionary<EventID, Action<object>>();
	}

	public void RegisterEvent(EventID i_ID, Action <object> i_CallBack)
	{
		if(m_EventDict.ContainsKey(i_ID))
		{
			m_EventDict[i_ID] += i_CallBack;
		}
		else
		{
			m_EventDict.Add(i_ID, i_CallBack);
		}
	}

	public void UnregisterEvent(EventID i_ID, Action<object> i_CallBack)
	{
		if(m_EventDict.ContainsKey(i_ID))
		{
			m_EventDict[i_ID] -= i_CallBack;
		}
		else
		{
			Debug.LogError("The event you are unregistering doesn't exist.");
		}
	}

	public void DispatchEvent(EventID i_ID, object i_Param = null)
	{
		if(m_EventDict.ContainsKey(i_ID))
		{
			m_EventDict[i_ID](i_Param);
		}
		else
		{
			Debug.LogError("The event you are dispatching doesn't exist.");
		}
	}
}
