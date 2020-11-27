using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Default,
    Equipment,
    Food, 
    Loot
}

public abstract class ItemObject : ScriptableObject
{
    public string ID;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
[System.Serializable]
public class Item
{
    public string Name;
    public string ID;
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.ID;
    }
}
