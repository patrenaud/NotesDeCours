using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_LoadingScreen;

	private static LevelManager m_Instance;
	public static LevelManager Instance
	{
		get { return m_Instance; }
	}

	private void Awake()
	{
		if(m_Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			m_Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		m_LoadingScreen.SetActive(false);
	}

	private void StartLoading()
	{
		Debug.Log("LoadingScreen ON");
		m_LoadingScreen.SetActive(true);
		//Play animation
	}

	private void OnLoadingDone(Scene i_Scene, LoadSceneMode i_Mode)
	{
		Debug.Log("LoadingScreen OFF");
		//Stop animation
		//We remove the function from the action/event list
		SceneManager.sceneLoaded -= OnLoadingDone;
		m_LoadingScreen.SetActive(false);
		//m_IsLoadingDone = true;
	}

	public void ChangeLevel(string i_Scene)
	{
		Debug.Log("ChangeLevel");
		StartLoading();
		SceneManager.LoadScene(i_Scene);
		//StartCoroutine qui attends 3 secondes et m_Isloading == true;
		
		//Action/Events that trigger automatically the given function
		//We add the function to the action/event list
		SceneManager.sceneLoaded += OnLoadingDone;
	}
}
