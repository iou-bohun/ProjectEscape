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
        //�κ����� 1~4 ������ �ε����� �����ҽ� 0~3�̱⿡ �����ް� -1���� �ʿ伺�� ����
        //0~3�� ������ ĭ -1�� ��ĭ���� ����
        //������ Ű�е带 �����ϸ� ������ �Ϳ� ���� currentitem�� ������ ����
        //currentitem�� ���� ���� ������ �ٽ� -1�� ����
        //��ĭ�� Ű�� �����ҽ� ������ ��� ����
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
