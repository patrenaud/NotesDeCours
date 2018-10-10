using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreeLookUserInput : MonoBehaviour
{
    private CinemachineFreeLook m_FreeLookCamera;


	private void Start ()
    {
        m_FreeLookCamera = GetComponent<CinemachineFreeLook>();
	}
	

	private void Update ()
    {
        // Ceci est pour contrôller un personnage avec une manette
        m_FreeLookCamera.m_XAxis.m_InputAxisValue = Input.GetAxisRaw("Horizontal2");
        m_FreeLookCamera.m_YAxis.m_InputAxisValue = Input.GetAxisRaw("Vertical2");
	}
}
