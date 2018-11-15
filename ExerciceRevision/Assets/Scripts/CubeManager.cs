using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour 
{

	private Dictionary <CubeID.CubeColor, TestCube> m_CubeList = new Dictionary<CubeID.CubeColor, TestCube>();

	private List<GameObject> m_Pos = new List<GameObject>();	

	private static CubeManager m_Instance;
	public static CubeManager Instance
	{
		get {return m_Instance;}
	}

	private void Awake()
	{
		if(m_Instance == null)
		{
			m_Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this);
		}
	}	

	public void SetCubeInDict(CubeID.CubeColor color, TestCube script)
	{
		m_CubeList.Add(color, script);
		m_Pos.Add(script.gameObject);

	}

	public List<GameObject> GetCubes()
	{
		return m_Pos;
	}

	public void ShuffleCubes()
	{
		List<int> m_RandomIndex = new List<int> {0,1,2};
		List<Transform> m_PosCopy = new List<Transform>();

		for(int i = 0; i < m_Pos.Count - 1; i++)
		{
			int randInt = Random.Range(0,m_RandomIndex.Count-1);
			m_PosCopy[i] = m_Pos[randInt].transform;
			m_RandomIndex.Remove(randInt);

		}
		
		for(int i = 0; i < m_Pos.Count - 1; i++)
		{
			m_Pos[i].transform.position = m_PosCopy[i].position;
		}
	}

	public void ScaleUp(GameObject cube)
	{
		cube.transform.localScale = new Vector3(2,2,2);
	}
}
