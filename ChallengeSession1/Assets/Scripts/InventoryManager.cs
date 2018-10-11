using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_InventoryPanel;
    [SerializeField]
    private List<BoxCollider2D> m_BoundingBoxes = new List<BoxCollider2D>();

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

    public void UpdateItemStatus(GameObject item, Vector2 initialPos)
    {
        for (int i = 0; i < m_BoundingBoxes.Count; i++)
        {
            BoxCollider2D col = item.GetComponent<BoxCollider2D>();
            if(m_BoundingBoxes[i].bounds.Intersects(col.bounds))
            {
                // This is to see if item is in a character slot
                if(m_BoundingBoxes[i].gameObject.layer == LayerMask.NameToLayer("CharSlot"))
                {
                    item.GetComponent<Items2>().Equip();
                }
                else
                {
                    item.GetComponent<Items2>().UnEquip();
                }

                item.transform.localPosition = m_BoundingBoxes[i].transform.localPosition;
                return;
            } 
        }
        item.transform.localPosition = initialPos;
    }
}
