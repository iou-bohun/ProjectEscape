using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjects : MonoBehaviour, IInteractable
{
    public ItemData item;

    public string GetInteractPrompot()
    {
        return string.Format("Pickup {0}", item.disPlayName);
    }

    //플레이어 상호작용키 (E) 
    public void OnInteract()
    {
        //Inventory.Instance.AddItem(item);
        Destroy(gameObject);
        Debug.Log("상호작용");
    }
}
