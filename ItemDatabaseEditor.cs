using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ItemDatabaseEditor : EditorWindow
{
    private ItemDatabase itemDatabase;
    private ItemType newItemType = ItemType.Resource;
    private int newItemID;
    private string newItemName;
    private Sprite newItemSprite;

    [MenuItem("Window/Item Database Editor")]
    public static void ShowWindow()
    {
        GetWindow<ItemDatabaseEditor>("Item Database Editor");
    }

    void OnGUI()
    {
        // Select the ItemDatabase
        itemDatabase = (ItemDatabase)EditorGUILayout.ObjectField("Item Database: ", itemDatabase, typeof(ItemDatabase), false);

        if (itemDatabase)
        {
            // Display existing items based on their type
            EditorGUILayout.LabelField("Items in Database");

            EditorGUILayout.LabelField("Resources:");
            DisplayItems(itemDatabase.allResourceItems);

            EditorGUILayout.LabelField("Craftables:");
            DisplayItems(itemDatabase.allCraftableItems);

            EditorGUILayout.LabelField("Specials:");
            DisplayItems(itemDatabase.allSpecialItems);

            // Create new items
            EditorGUILayout.LabelField("Create New Item");

            newItemType = (ItemType)EditorGUILayout.EnumPopup("New Item Type:", newItemType);
            newItemID = EditorGUILayout.IntField("New Item ID:", newItemID);
            newItemName = EditorGUILayout.TextField("New Item Name:", newItemName);
            newItemSprite = (Sprite)EditorGUILayout.ObjectField("New Item Sprite:", newItemSprite, typeof(Sprite), false);

            if (GUILayout.Button("Add New Item"))
            {
                AddNewItem();
            }

            if (GUILayout.Button("Save Database"))
            {
                SaveDatabase();
            }

        }
    }
    void SaveDatabase()
    {
        if (itemDatabase)
        {
            EditorUtility.SetDirty(itemDatabase);
            AssetDatabase.SaveAssets();
        }
    }


    void DisplayItems<T>(List<T> items) where T : GameItem
    {
        foreach (GameItem item in items)
        {
            EditorGUILayout.LabelField("ID: " + item.itemID + ", Name: " + item.itemName);
        }
    }


    void AddNewItem()
    {
        if (itemDatabase)
        {
            GameItem newItem;

            switch (newItemType)
            {
                case ItemType.Resource:
                    newItem = ScriptableObject.CreateInstance<ResourceItem>();
                    itemDatabase.allResourceItems.Add((ResourceItem)newItem);
                    break;
                case ItemType.Craftable:
                    newItem = ScriptableObject.CreateInstance<CraftableItem>();
                    itemDatabase.allCraftableItems.Add((CraftableItem)newItem);
                    break;
                case ItemType.Special:
                    newItem = ScriptableObject.CreateInstance<SpecialItem>();
                    itemDatabase.allSpecialItems.Add((SpecialItem)newItem);
                    break;
                default:
                    return;
            }

            newItem.itemID = newItemID;
            newItem.itemName = newItemName;
            newItem.itemSprite = newItemSprite;
            newItem.itemType = newItemType;

            // Save the new item as an asset
            AssetDatabase.CreateAsset(newItem, "Assets/GameItems/" + newItemName + ".asset");
            AssetDatabase.SaveAssets();
        }
    }


}
