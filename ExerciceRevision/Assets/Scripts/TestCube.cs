using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour 
{
	public CubeID.CubeColor m_Color;
	public int m_Index;

	private void Awake()
	{
		if( m_Color == CubeID.CubeColor.blue)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
		else if(m_Color == CubeID.CubeColor.red)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
		else if(m_Color == CubeID.CubeColor.yellow)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.color = Color.black;
			Debug.Log("Missing Color on the cube Mofo");
		}

		CubeManager.Instance.SetCubeInDict(m_Color, this);
	}

}
