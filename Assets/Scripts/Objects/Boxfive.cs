using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boxfive : MonoBehaviour
{
    private bool walletCheck;
    private bool idCardCheck;
    private bool driveIdCheck;
    private bool amuletCheck;
    [SerializeField]private bool allItemChecked;
    [SerializeField] private GameObject[] collectableItem;
    public GameObject player;
    public InventoryInput invenInput;


    private void Awake()
    {
        invenInput = player.GetComponent<InventoryInput>();
    }

    private void Start()
    {
        walletCheck = false;
        idCardCheck = false;
        driveIdCheck = false;
        amuletCheck = false;
        allItemChecked = false;
    }
    private void OnMouseOver()
    {
        if (player)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < 5)
            {
                if (Input.GetMouseButtonDown(0) && Inventory.i.HandItem != null)
                {
                    CheckHandItem();
                }
            }
        }
    }

    private void CheckHandItem()
    {
        for (int i = 0; i < collectableItem.Length; i++)
        {
            if (Inventory.i.HandItem.tag == collectableItem[i].tag)
            {
                switch (Inventory.i.HandItem.tag)
                {
                    case "wallet":
                        walletCheck = true;
                        break;
                    case "idCard":
                        idCardCheck = true;
                        break;
                    case "driveId":
                        driveIdCheck = true;
                        break;
                    case "amulet":
                        amuletCheck = true;
                        break;
                }
                CollectItem(i);
                break;
            }
        }
    }

    private void CollectItem(int index)
    {
        int currentIndex = invenInput.currentIndex;
     
       
        Inventory.i.DeleteItem(currentIndex);
        CheckClear();
    }

    private void CheckClear()
    {
        if(walletCheck && idCardCheck && driveIdCheck && amuletCheck)
        {
            allItemChecked = true;
        }
    }
}
