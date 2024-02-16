using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resources,
    Equipable,
}

public enum ItemSoundType
{
    Default,
    Paper,
    Metal
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string disPlayName;
    public string description;
    public ItemType type;
    public ItemSoundType soundType;
    public Sprite icon;
    public GameObject dropPrefab;
    public GameObject handPrefab;
}
