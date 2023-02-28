using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInventory
{
    public List<VisualItem> VisualItems = new List<VisualItem>();
    public Dictionary<ItemType, VisualItem> EquipedItems = new Dictionary<ItemType, VisualItem>();

    //Injection
    private SignalBus signalBus;

    private CurrencyItem currency;
    public int CurrencyAmount => currency.Quantity;

    public PlayerInventory(SignalBus signalBus)
    {
        this.signalBus = signalBus;

        foreach(ItemType type in Enum.GetValues(typeof(ItemType)))
        {
            //this equips a inoffensive currency
            EquipedItems.Add(type, null);
        }
    }

    #region Buy/Sell
    public void AddItem(VisualItem item)
    {
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
                Unequip(item.Type);
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

    public void SetCurrencyItem(CurrencyItem item)
    {
        currency = item;
    }

    //Signal should be fired here
    public void ChangeCurrencyAmount(int amount)
    {
        currency.Quantity += amount;
        signalBus.Fire(new OnCurrencyChangedSignal());
    }
    #endregion

    #region Equip
    public void EquipItem(VisualItem visualItem)
    {
        if (EquipedItems[visualItem.Type] != null)
        {
            EquipedItems[visualItem.Type].Equipped = false;
        }
        EquipedItems[visualItem.Type] = visualItem;
        visualItem.Equipped = true;
        signalBus.Fire(new OnItemEquippedSignal(visualItem));
    }

    public void Unequip(ItemType type)
    {
        EquipedItems[type].Equipped = false;
        EquipedItems[type] = null;
        signalBus.Fire(new OnItemUnequippedSignal(type));
    }
    #endregion
}
