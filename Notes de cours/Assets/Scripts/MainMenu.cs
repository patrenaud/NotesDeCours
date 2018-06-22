using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnSwitchMusicClick()
    {
		AudioManager.Instance.SwitchMusic(2f);
    }
}
