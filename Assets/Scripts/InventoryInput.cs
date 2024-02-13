using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInput : MonoBehaviour
{
    int currentIndex = -1;

    public void DropItemInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && currentIndex != -1)
        {
            Inventory.i.DropItem(currentIndex);
            currentIndex = -1;
        }
    }
    #region Input
    public void Item1Input(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            currentIndex = 0;
        }
        Hand();
    }
    public void Item2Input(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            currentIndex = 1;
        }
        Hand();
    }
    public void Item3Input(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            currentIndex = 2;
        }
        Hand();
    }
    public void Item4Input(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            currentIndex = 3;
        }
        Hand();
    }
    void Hand()
    {
        Inventory.i.CatchItem(currentIndex);
    }
    #endregion
}
