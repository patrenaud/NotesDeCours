using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineTrigger : MonoBehaviour 
{

	public PlayableDirector m_Timeline;

	// To make it work once
	public bool m_UseOneTimeonly = false;
	private bool m_HasBeenUsed = false;


	private void OnTriggerEnter(Collider aCol)
	{

		// make it work once
		if(!m_HasBeenUsed)
		{
			m_Timeline.Play();
			if(m_UseOneTimeonly)
			{
				m_HasBeenUsed = true;
			}			
		}

		//m_Timeline.Play();

	}

	private void OnTriggerExit(Collider aCol)
	{
		
	}

}
