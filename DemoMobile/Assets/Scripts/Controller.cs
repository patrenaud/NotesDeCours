using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{

	public int m_Index;

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void OnOK(string message)
	{
		Debug.Log("Message received: " + message);
	}

	public void PositiveCallback(string message)
	{
		Debug.Log("Message received: " + message);
	}

	public void NeutralCallback(string message)
	{
		Debug.Log("Message received: " + message);
	}

	public void NegativeCallback(string message)
	{
		Debug.Log("Message received: " + message);
	}

	public void ShowDialog(
		string titleText,
		string messageText,
		string positiveText,
		string neutralText,
		string negativeText, 
		Action<string> positiveCallback,
		Action<string> neutralCallback,
		Action<string> negativeCallback)
	{
		// doit cérifier si callback existe

		using(AndroidJavaClass DialogPlugin = new AndroidJavaClass("ca.patrickrenaudbart.lab5.plugin.DialogPlugin"))
		{
			DialogPlugin.CallStatic("ShowDialog",titleText, messageText, positiveText, neutralText, negativeText, 
			positiveCallback == null ? "" : ((Component)positiveCallback.Target).gameObject.name, 
			positiveCallback == null ? "" : positiveCallback.Method.Name,
			neutralCallback == null ? "" : ((Component)neutralCallback.Target).gameObject.name, 
			neutralCallback == null ? "" : neutralCallback.Method.Name,
			negativeCallback == null ? "" : ((Component)negativeCallback.Target).gameObject.name, 
			negativeCallback == null ? "" : negativeCallback.Method.Name);
		}
	}

	public void OnButtonClick()
	{
		Debug.Log("This is a log, mofos");

		PlayerPrefs.SetString("This is a key", "This is a value");
		PlayerPrefs.Save();

		/* 
		// AlertDialog.Builder builder = new AlertDialog.Builder(UnityPlayer.currentActivity) ceci est en Java
		// En C#:
		using (AndroidJavaClass UnityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		using (AndroidJavaObject currentActivity = UnityPlayerClass.GetStatic<AndroidJavaClass>("currentActivity")) // va chercher la current activity dans Java
		
		// Donne la classe builder
		using (AndroidJavaObject builder = new AndroidJavaObject("android.app.AlertDialog$Builder", currentActivity))
		{
			builder.Call<AndroidJavaObject>("setMessage", "this is my message");
			builder.Call<AndroidJavaObject>("show");
		}
		*/


		ShowDialog("titleText", "messageText", "positiveText", "neutralText", "negativeText", PositiveCallback,  NeutralCallback,  NegativeCallback);
	}

	public void ShowStuff(int Index)
	{
		switch (Index)
		{
			case 1 : ShowDialog("titleText", "messageText", "positiveText", "neutralText", "negativeText", PositiveCallback,  NeutralCallback,  NegativeCallback);
			break;
			case 2 : ShowDialog("titleText", "messageText", "positiveText", "neutralText", "negativeText", null,  null,  null);
			break;
			case 3 : ShowDialog("titleText", "messageText", "", "", "", PositiveCallback,  NeutralCallback,  NegativeCallback);
			break;
			case 4 : ShowDialog("titleText", "messageText", "", "", "", null,  null,  null);
			break;
			case 0:
			break;
		}
	}
}
