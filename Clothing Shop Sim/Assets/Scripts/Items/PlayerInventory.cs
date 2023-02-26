using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private List<Item> items;

    private CurrencyItem currency;

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
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
