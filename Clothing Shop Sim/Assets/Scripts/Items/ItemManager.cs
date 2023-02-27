using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;

public class ItemManager
{
    const string ITEMS_PATH = "ScriptableObjects/Items";

    private PlayerInventory playerInventory;
    public PlayerInventory Inventory => playerInventory;

    public List<VisualItem> VisualItems = new List<VisualItem>();

    private List<VisualItem> availableItems;

    public ItemManager(PlayerInventory inventory)
    {
        playerInventory = inventory;

        Object[] items = Resources.LoadAll(ITEMS_PATH, typeof(ScriptableObject));
        foreach (VisualItem item in items)
        {
            VisualItems.Add(item);
        }
    }

    public bool HasItem(Item item)
    {
        return item.Quantity > 0;
    }

    public void RefreshAvailableItems()
    {
        availableItems = new List<VisualItem>(VisualItems);
        foreach(VisualItem item in playerInventory.VisualItems)
        {
            availableItems.Remove(item);
        }
    }

    public VisualItem FindAvailableVisualItemForMannequin()
    {
        int randomIndex;
        while(availableItems.Count > 0)
        {
            randomIndex = Random.Range(0, availableItems.Count);
            VisualItem item = availableItems[randomIndex];
            if (HasItem(item))
            {
                availableItems.RemoveAt(randomIndex);
            }
            else
            {
                availableItems.RemoveAt(randomIndex);
                return item;
            }
        }
        return null;
    }
}
