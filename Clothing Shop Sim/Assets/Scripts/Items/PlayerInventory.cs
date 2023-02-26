using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private List<Item> items;

    private CurrencyItem currency;
    public int CurrencyAmount => currency.Quantity;

    public void AddItem(Item item)
    {
        //change this to save
        items.Add(item);
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
