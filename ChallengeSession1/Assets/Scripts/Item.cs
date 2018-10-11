using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Item : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 m_InitialPosition;
    private bool m_IsEquipped = false;

    [SerializeField]
    private Collider2D m_BoundingBox;
    [SerializeField]
    private Collider2D m_CharacterSlotBoundingBox;

    private void Awake()
    {
        m_InitialPosition = transform.localPosition;
    }

    // Cette fonction est appeler pendant le Drag
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_BoundingBox.bounds.Intersects(m_CharacterSlotBoundingBox.bounds))
        {
            m_IsEquipped = true;
            transform.localPosition = m_CharacterSlotBoundingBox.gameObject.transform.localPosition;
        }
        else
        {
            m_IsEquipped = false;
            transform.localPosition = m_InitialPosition;
        }
    }
}
