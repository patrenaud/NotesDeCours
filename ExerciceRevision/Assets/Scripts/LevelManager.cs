using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

	[SerializeField]
	private GameObject m_LoadingScreen;
	[SerializeField]
	private float m_LoadTimer;

	private static LevelManager m_Instance;
	public static LevelManager Instance
	{ 
		get { return m_Instance; }
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
		m_LoadingScreen.SetActive(false);
	}

	private void StartLoading()
	{
		m_LoadingScreen.SetActive(true);
		StartCoroutine(LoadingTimer());
	}

	private IEnumerator LoadingTimer()
	{
		yield return new WaitForSeconds(m_LoadTimer);
		m_LoadingScreen.SetActive(false);
	}

	private void OnLoadingDone(Scene aScene, LoadSceneMode aMode)
	{
		SceneManager.sceneLoaded -= OnLoadingDone;
	}

	public void ChangeLevel(string aLevel)
	{
		StartLoading();
		SceneManager.LoadScene(aLevel);

		SceneManager.sceneLoaded += OnLoadingDone;
	}
}
