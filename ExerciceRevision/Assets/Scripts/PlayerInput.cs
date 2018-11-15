using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	private GameObject m_Cube1;
	private GameObject m_Cube2;
	private GameObject m_Cube3;

	private Vector3 m_Cube1Scale = new Vector3();
	private Vector3 m_Cube2Scale = new Vector3();
	private Vector3 m_Cube3Scale = new Vector3();


	private void Start()
	{
		m_Cube1 = CubeManager.Instance.GetCubes()[0];
		m_Cube1Scale = CubeManager.Instance.GetCubes()[0].transform.localScale;

		m_Cube2 = CubeManager.Instance.GetCubes()[1];
		m_Cube2Scale = CubeManager.Instance.GetCubes()[1].transform.localScale;

		m_Cube3 = CubeManager.Instance.GetCubes()[2];
		m_Cube3Scale = CubeManager.Instance.GetCubes()[2].transform.localScale;
	}


	private void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			CubeManager.Instance.ShuffleCubes();
		}

		if(Input.GetKey(KeyCode.Keypad1))
		{
			CubeManager.Instance.ScaleUp(m_Cube1);
		}
		else if(Input.GetKeyUp(KeyCode.Keypad1))
		{
			m_Cube1.transform.localScale = m_Cube1Scale;
		}


		if (Input.GetKey(KeyCode.Keypad2))
		{
			CubeManager.Instance.ScaleUp(m_Cube2);	
		}
		else if(Input.GetKeyUp(KeyCode.Keypad2))
		{
			m_Cube2.transform.localScale = m_Cube2Scale;
		}


		if (Input.GetKey(KeyCode.Keypad3))
		{
			CubeManager.Instance.ScaleUp(m_Cube3);	
		}
		else if (Input.GetKeyUp(KeyCode.Keypad3))
		{
			m_Cube3.transform.localScale = m_Cube3Scale;
		}
	}
}
