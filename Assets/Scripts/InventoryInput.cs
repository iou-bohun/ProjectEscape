using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInput : MonoBehaviour
{
    int currentItem;
    public void ItemChoiceInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) 
        {
            Debug.Log(context.ReadValue<Vector2>());
        }
    }
    public void DropItemInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && currentItem != 0)
        {
            Inventory.i.DropItem(currentItem);
            currentItem = 0;
        }
    }
}
