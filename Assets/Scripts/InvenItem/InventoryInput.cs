using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            if (currentIndex != 0)
            {
                currentIndex = 0;
                Hand();
            }
            else
            {
                Hand();
                currentIndex = -1;
            }
        }
    }
    public void Item2Input(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (currentIndex != 1)
            {
                currentIndex = 1;
                Hand();
            }
            else
            {
                Hand();
                currentIndex = -1;
            }
        }
    }
    public void Item3Input(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (currentIndex != 2)
            {
                currentIndex = 2;
                Hand();
            }
            else
            {
                Hand();
                currentIndex = -1;
            }
        }
    }
    public void Item4Input(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (currentIndex != 3)
            {
                currentIndex = 3;
                Hand();
            }
            else
            {
                Hand();
                currentIndex = -1;
            }
        }
    }
    void Hand()
    {
        Inventory.i.CatchItem(currentIndex);
    }
    #endregion

    public void ExamineInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Inventory.i.ShowExmineUI();
            Inventory.i.SetExamineItem(currentIndex);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            Inventory.i.HideExaminUI();
        }
    }
}
