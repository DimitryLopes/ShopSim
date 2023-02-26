using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public List<VisualItem> VisualItems = new List<VisualItem>();

    private CurrencyItem currency;
    public int CurrencyAmount => currency.Quantity;

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
            VisualItems.Remove(item);
        }
    }

    public bool HasItem(VisualItem item)
    {
        return VisualItems.Contains(item);
    }

    public bool HasEnoughCurrency(int amount)
    {
        return currency.Quantity >= amount;
    }

    public void RemoveCurrency(int amount)
    {
        currency.Quantity -= amount;
    }
}
