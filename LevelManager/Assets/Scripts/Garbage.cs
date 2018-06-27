using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour 
{
	public GameObject m_Prefab;
	// Use this for initialization
	void Start () 
	{
		LoopDaWoop(new List<GameObject>());
		StartCoroutine(CreateGarbage());
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 v = new Vector3();
		GameObject obj;
		obj = GetComponent<GameObject>();
		//Instantiate(m_Prefab, Vector3.zero, Quaternion.identity).AddComponent<Rigidbody>();
		CallGarbage();
	}

	public void CallGarbage()
	{
		StartCoroutine(CreateGarbage());
		Instantiate(m_Prefab, Vector3.zero, Quaternion.identity).AddComponent<Rigidbody>();
	}

	public List<GameObject> LoopDaWoop(List<GameObject> i_Go)
	{
		LoopDaWoop(new List<GameObject>());
		return new List<GameObject>();
	}

	private IEnumerator CreateGarbage()
	{
		while(true)
		{
			Vector3 v = new Vector3();
			GameObject obj;
			obj = GetComponent<GameObject>();
			//Instantiate(m_Prefab, Vector3.zero, Quaternion.identity).AddComponent<Rigidbody>();

			yield return new WaitForSeconds(0.1f);
		}
	}
}
