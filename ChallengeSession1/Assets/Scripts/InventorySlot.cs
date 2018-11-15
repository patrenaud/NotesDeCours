using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour 
{
	public Collider2D m_BoundingBox;

	public Items2 m_ItemInSlot = null;

	public bool m_IsFull;
}
