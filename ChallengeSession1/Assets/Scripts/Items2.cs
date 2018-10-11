using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Items2 : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector2 m_InitialPosition;
    public bool m_IsEquipped = false;

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
        InventoryManager.Instance.UpdateItemStatus(gameObject, m_InitialPosition);
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

