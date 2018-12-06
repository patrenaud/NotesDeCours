using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour 
{

	private Vector3 m_Pos = new Vector3();
	private string m_CurrentScene;
	private FighterSkill[] m_Skills;

	private bool m_CanSave = false;


	private void Update()
	{
		if(m_CanSave)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Game.save.SaveGame();
				Game.ui.DisplayDialogBox("Game saved");
			}
		}

	}


	private void OnTriggerEnter2D (Collider2D aOther)
	{
		if(aOther.gameObject == Game.player.gameObject)
		{
			m_CanSave = true;
		}		
	}

	private void OnTriggerExit2D (Collider2D aOther)
	{
		if(aOther.gameObject == Game.player.gameObject)
		{
			m_CanSave = false;
		}
	}
}
