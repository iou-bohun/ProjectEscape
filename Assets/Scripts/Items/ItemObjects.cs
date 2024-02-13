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

    //�÷��̾� ��ȣ�ۿ�Ű (E) 
    public void OnInteract()
    {
        if (Inventory.i.GetItem(item))
        {
            Destroy(gameObject);
        }
    }
}
