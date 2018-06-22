using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2Enums : MonoBehaviour
{

    [SerializeField]
    private LayerMask m_Mask;
    private int a = 0;
    private int b = 10;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray RaycastHit = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(RaycastHit, 1000f, m_Mask))
            {
                Debug.Log("KILL IT WITH CHEEEESE");
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            m_Mask = LayerMask.GetMask("Enemy") | LayerMask.GetMask("Princess") | LayerMask.GetMask("Default");
        }
    }

    private void OnTriggerEnter(Collider i_Col)
    {
        //i_Col.gameObject.layer == LayerMask.NameToLayer("Enemy")

        bool JimmyComprend = i_Col.gameObject.layer == LayerMask.NameToLayer("Enemy") ? true : false;
        int MatComprend = a < b ? 100 : 0;
        string PatEnPatinComprend = Physics.gravity != Vector3.zero ? "Programmeur" : "Prof de science";
    }
}
