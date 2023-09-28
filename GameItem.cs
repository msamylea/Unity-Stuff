using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resource,
    Craftable,
    Special
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Game Item/Base Item")]
public class GameItem : ScriptableObject
{
    public string itemName;
    public int itemID;
    public ItemType itemType;
    public Sprite itemSprite;
    // Add other common properties here
}

[CreateAssetMenu(fileName = "NewResourceItem", menuName = "Game Item/Resource Item")]
public class ResourceItem : GameItem
{
    public int gatherTime;
    // Add properties specific to resource items
}

[CreateAssetMenu(fileName = "NewCraftableItem", menuName = "Game Item/Craftable Item")]
public class CraftableItem : GameItem
{
    public int craftingTime;
    public List<ResourceItem> requiredResources;
    // Add properties specific to craftable items
}

[CreateAssetMenu(fileName = "NewSpecialItem", menuName = "Game Item/Special Item")]
public class SpecialItem : GameItem
{
    public string specialEffect;
    // Add properties specific to special items
}


