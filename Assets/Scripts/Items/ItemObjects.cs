using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjects : MonoBehaviour, IInteractable
{
    public ItemData item;

    private void Start()
    {
        GameManager.Instance.OnLoopEvent += LoopItem;
    }

    private void LoopItem()
    {
        if (transform.position.z > 14)
        {
            if (transform.position.y >= 4.2f)
            {
                transform.position = new Vector3(transform.position.x, -3.65f, transform.position.z);
            }
            else if (transform.position.y <= -3.65f)
            {
                transform.position = new Vector3(transform.position.x, 4.6f, transform.position.z);
            }
        }
    }

    public string GetInteractPrompot()
    {
        return string.Format("Pickup {0}", item.disPlayName);
    }

    //�÷��̾� ��ȣ�ۿ�Ű (E) 
    public void OnInteract()
    {
        if (Inventory.i.GetItem(item))
        {
            GameManager.Instance.OnLoopEvent -= LoopItem;
            Destroy(gameObject);
        }
    }
}
