using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory i;
    [SerializeField] Transform dropPos;
    [SerializeField] GameObject inventoryUi;
    public ItemData[] items;
    int InventorySize = 4;
    [SerializeField] Transform handParent;
    public GameObject HandItem;

    [Header("Examine")]
    [SerializeField] GameObject desctiptionUI;
    [SerializeField] TextMeshProUGUI desctiptionText;
    [SerializeField] Image handItemImage;
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
                PlayItemSFX(AnItem);
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
        PlayItemSFX(items[index]);
        UpdateInvenUi(index);
        if (HandItem != null)
        {
            Destroy(HandItem.gameObject);
            HandItem = null;
        }
        items[index] = null;
    }
    public void DeleteItem(int index)
    {
        if (items[index] == null)
        {
            return;
        }
        UpdateInvenUi(index);
        if (HandItem != null)
        {
            Destroy(HandItem.gameObject);
            HandItem = null;
        }
        items[index] = null;
    }
    public void UpdateInvenUi(int index, ItemData AnItem)
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
    public void UpdateInvenUi(int index)
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
        //정전이벤트에서 들고 있는 아이템이 플레쉬인지 확인
        if (HandItem == null) EventManager.I.handFlash = false;
        else if (HandItem.name == "Hand_flashLight")
        { 
            EventManager.I.handFlash = true;
            Debug.Log("플레쉬장착");
        }
        else EventManager.I.handFlash = false;

    }

    public void ShowExmineUI()
    {
        desctiptionUI.gameObject.SetActive(true);
        desctiptionText.text = null;
        handItemImage.sprite = null;
    }
    public void HideExaminUI()
    {
        desctiptionUI.gameObject.SetActive(false);
    }
    public void SetExamineItem(int index) 
    {
       if(index == -1)
        {
            return;
        }
        if (items[index] == null)
        {
            return;
        }
        else
        {
            desctiptionText.text = items[index].description;
            handItemImage.sprite = items[index].icon;
        }
    }
    public int CheckInven(string name)
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            if (items[i].disPlayName == name)
            {
                return i;
            }
        }
        return -1;
    }
    public void DestroyItem(string name)
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            if (items[i].disPlayName == name)
            {
                items[i] = null;
                CatchItem(i);
                UpdateInvenUi(i);
                return;
            }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < InventorySize; i++)
        {
            DeleteItem(i);
        }
    }

    private void PlayItemSFX(ItemData item)
    {
        switch ((int)item.soundType)
        {
            case (int)SoundType.Default:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.otherMovement, GameManager.Instance.player.transform.position);
                break;
            case (int)SoundType.Paper:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.paperMovement, GameManager.Instance.player.transform.position);
                break;
            case (int)SoundType.Metal:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.metalMovement, GameManager.Instance.player.transform.position);
                break;
        }
    }

    public enum SoundType
    {
        Default,
        Paper,
        Metal
    }
}
