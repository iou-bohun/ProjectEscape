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
    ItemData[] items;
    int InventorySize = 4;
    [SerializeField] Transform handParent;
    [SerializeField] GameObject HandItem;
    [SerializeField] Transform DropPos;
    Camera _camera;
    private void Awake()
    {
        if (i == null)
        {
            i = this;
            items = new ItemData[InventorySize];
            _camera = Camera.main;
        }
        else
        {
            Destroy(this);
        }
    }
    public bool GetItem(ItemData AnItem)
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
        GameObject temp = Instantiate(items[index].dropPrefab, dropPos.position, Quaternion.identity);
        //temp.GetComponent<Rigidbody>().velocity = Vector3.forward * 10;
        UpdateInvenUi(index);
        if (HandItem != null)
        {
            Destroy(HandItem.gameObject);
            HandItem = null;
        }
        items[index] = null;
    }
    void UpdateInvenUi(int index, ItemData AnItem)
    {
        if (AnItem != null)
        {
            GameObject slotImage = new GameObject();
            slotImage.transform.SetParent(inventoryUi.transform.GetChild(index).transform);
            slotImage.AddComponent<Image>().sprite = AnItem.icon;
            slotImage.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            slotImage.GetComponent<RectTransform>().localScale = Vector3.one;
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
            if (HandItem != null)
            {
                Destroy(HandItem.gameObject);
            }
            HandItem = null;
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
