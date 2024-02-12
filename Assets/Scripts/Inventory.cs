using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory i;
    [SerializeField] Transform dropPos;
    [SerializeField] GameObject inventoryUi;
    Item[] items;
    int InventorySize = 4;
    private void Awake()
    {
        if (i == null)
        {
            i = this;
            items = new Item[InventorySize];
        }
        else
        {
            Destroy(this);
        }
    }
    public bool GetItem(Item AnItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = AnItem;
                UpdateInvenUi(i,AnItem);
                return true;
            }
        }
        return false;
    }
    public void DropItem(int index)
    {
        if (items[index] == null)
        {
            return;
        }
        Instantiate(items[index].itemPrafab, dropPos.position, Quaternion.identity);
        UpdateInvenUi(index);
        items[index] = null;
    }
    public void UpdateInvenUi(int index,Item AnItem)
    {
        if (AnItem != null)
        {
            GameObject slotImage = new GameObject();
            slotImage.transform.SetParent(inventoryUi.transform.GetChild(index).transform);
            slotImage.AddComponent<Image>().sprite = AnItem.itemImage;
            slotImage.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }
    public void UpdateInvenUi(int index)
    {
        if (inventoryUi.transform.GetChild(index).transform.childCount == 1)
        {
            Destroy(inventoryUi.transform.GetChild(index).GetChild(0).gameObject);
        }
    }
}
