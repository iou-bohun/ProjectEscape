using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInput : MonoBehaviour
{
    int currentItem = 0;
    public void ItemChoiceInput(InputAction.CallbackContext context)
    {
        //인벤값은 1~4 하지만 인덱스로 적용할시 0~3이기에 값을받고 -1해줄 필요성이 있음
        //0~3은 아이템 칸 -1은 빈칸으로 설정
        //아이템 키패드를 선택하면 선택한 것에 따라 currentitem을 설정할 예정
        //currentitem과 같은 값이 나오면 다시 -1을 해줌
        //빈칸의 키를 선택할시 적용할 방법 생각
    }
    public void DropItemInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && currentItem != -1)
        {
            Inventory.i.DropItem(currentItem);
            currentItem = -1;
        }
    }
}
