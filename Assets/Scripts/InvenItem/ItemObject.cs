using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    public string ItemName()
    {
        return item.itemName;
    }
    public void Put()
    {
        Inventory.i.GetItem(item);
        Destroy(gameObject);
    }
}
