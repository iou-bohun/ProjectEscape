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
    [SerializeField] Transform handParent;
    [SerializeField] GameObject HandItem;
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
                UpdateInvenUi(i, AnItem);
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
        Instantiate(items[index].itemPrefab, dropPos.position, Quaternion.identity);
        UpdateInvenUi(index);
        if (HandItem != null)
        {
            Destroy(HandItem.gameObject);
            HandItem = null;
        }
        items[index] = null;
    }
    void UpdateInvenUi(int index, Item AnItem)
    {
        if (AnItem != null)
        {
            GameObject slotImage = new GameObject();
            slotImage.transform.SetParent(inventoryUi.transform.GetChild(index).transform);
            slotImage.AddComponent<Image>().sprite = AnItem.itemImage;
            slotImage.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }
    void UpdateInvenUi(int index)
    {
        if (inventoryUi.transform.GetChild(index).transform.childCount == 1)
        {
            Destroy(inventoryUi.transform.GetChild(index).GetChild(0).gameObject);
        }
    }
    public void CatchItem(int index)
    {
        if (items[index] == null)
        {
            Debug.Log("1");
            if (HandItem != null)
            {
                Destroy(HandItem.gameObject);
            }
            HandItem = null;
            Debug.Log("2");
        }
        else if (HandItem == null && items[index] != null)
        {
            HandItem = Instantiate(items[index].handPrefab, handParent);
            HandItem.name = items[index].handPrefab.name;
        }
        else if (HandItem.name == items[index].handPrefab.name)
        {
            Destroy(HandItem.gameObject);
            HandItem = null;
        }
        else if (HandItem != null && items[index] != null)
        {
            Destroy(HandItem.gameObject);
            HandItem = Instantiate(items[index].handPrefab, handParent);
            HandItem.name = items[index].handPrefab.name;
        }
    }
}
