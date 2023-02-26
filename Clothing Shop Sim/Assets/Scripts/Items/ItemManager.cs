using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;

public class ItemManager
{
    const string ITEMS_PATH = "ScriptableObjects/Items";
    public List<VisualItem> VisualItems = new List<VisualItem>();

    public ItemManager()
    {
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

    public VisualItem FindAvailableVisualItemForMannequin(List<Mannequin> mannequins)
    {
        List<VisualItem> uncheckedItems = VisualItems;
        foreach(Mannequin mannequin in mannequins)
        {
            if (mannequin.Item != null)
            {
                if (uncheckedItems.Contains(mannequin.Item))
                {
                    uncheckedItems.Remove(mannequin.Item);
                }
            }
        }

        int randomIndex;
        while(uncheckedItems.Count > 0)
        {
            randomIndex = Random.Range(0, uncheckedItems.Count);
            if (HasItem(uncheckedItems[randomIndex]))
            {
                uncheckedItems.RemoveAt(randomIndex);
            }
            else
            {
                return uncheckedItems[randomIndex];
            }
        }
        return null;
    }
}
