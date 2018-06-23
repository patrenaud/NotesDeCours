using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_InventoryPanel;


    private static InventoryManager m_Instance;

    public static InventoryManager Instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this;       
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CallInventory()
    {
        m_InventoryPanel.SetActive(!m_InventoryPanel.activeSelf);
    }
}
