using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Game Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ResourceItem> allResourceItems;
    public List<CraftableItem> allCraftableItems;
    public List<SpecialItem> allSpecialItems;

    // Add methods to get items by ID or name
    // For example:
    public GameItem GetItemByID(int id, ItemType type)
    {
        switch (type)
        {
            case ItemType.Resource:
                return allResourceItems.Find(item => item.itemID == id);
            case ItemType.Craftable:
                return allCraftableItems.Find(item => item.itemID == id);
            case ItemType.Special:
                return allSpecialItems.Find(item => item.itemID == id);
            default:
                return null;
        }
    }
}
