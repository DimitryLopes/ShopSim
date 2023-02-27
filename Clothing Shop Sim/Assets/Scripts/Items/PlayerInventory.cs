using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public List<VisualItem> VisualItems = new List<VisualItem>();
    public Dictionary<ItemType, VisualItem> EquipedItems = new Dictionary<ItemType, VisualItem>();

    private CurrencyItem currency;
    public int CurrencyAmount => currency.Quantity;

    #region Buy/Sell
    public void AddItem(VisualItem item)
    {
        //change this to save
        if (HasItem(item) == false)
        {
            VisualItems.Add(item);
        }
    }

    public void RemoveItem(VisualItem item)
    {
        if (HasItem(item))
        {
            if (EquipedItems[item.Type] == item)
            {
                EquipedItems[item.Type] = null;
            }
            VisualItems.Remove(item);
        }
    }
    #endregion

    public bool HasItem(VisualItem item)
    {
        return VisualItems.Contains(item);
    }

    #region Currency
    public bool HasEnoughCurrency(int amount)
    {
        return currency.Quantity >= amount;
    }

    //Signal should be fired here
    public void ChangeCurrencyAmount(int amount)
    {
        currency.Quantity -= amount;
    }
    #endregion

    #region Equip
    public void EquipItem(ItemType type, VisualItem visualItem)
    {
        if(EquipedItems.ContainsKey(type) == false)
        {
            EquipedItems.Add(type, visualItem);
            return;
        }
        EquipedItems[type] = visualItem;
    }
    #endregion
}
