﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    	
	private void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryManager.Instance.CallInventory();
        }
	}
}
