using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private AudioClip m_AudioClip;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10f, 10f, 100f, 100f), "Play Footsteps"))
        {
			AudioManager.Instance.PlaySFX(m_AudioClip, transform.position);
            Debug.Log("Sound");
        }
    }
}
