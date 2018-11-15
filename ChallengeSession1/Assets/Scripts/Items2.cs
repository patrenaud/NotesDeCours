using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Items2 : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Vector2 m_InitialPosition;
    public bool m_IsEquipped = false;
    public InventorySlot m_ItemSlot;
    

    private void SelectItem()
    {
        m_InitialPosition = transform.localPosition;        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        SelectItem();
    }

    // Cette fonction est appeler pendant le Drag
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        InventoryManager.Instance.UpdateItemStatus(gameObject, m_InitialPosition, m_ItemSlot);
    }

    public void Equip()
    {
        m_IsEquipped = true;
    }

    public void UnEquip()
    {
        m_IsEquipped = false;
    }
}

