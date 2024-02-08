using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resources,
    Equipable,
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string disPlayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;
}
