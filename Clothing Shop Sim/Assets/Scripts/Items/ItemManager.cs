using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;

public class ItemManager
{
    const string ITEMS_PATH = "ScriptableObjects/Items";

    private SignalBus signalBus;
    private PlayerInventory playerInventory;
    private List<VisualItem> availableItems;

    public PlayerInventory Inventory => playerInventory;

    public List<VisualItem> AllVisualItems = new List<VisualItem>();


    public ItemManager(PlayerInventory inventory, SignalBus signalBus)
    {
        playerInventory = inventory;
        this.signalBus = signalBus;
        signalBus.Subscribe<OnJobExcecutedSignal>(OnJobExecuted);
        GetAllVisualItems();
    }

    private void GetAllVisualItems()
    {
        Object[] items = Resources.LoadAll(ITEMS_PATH, typeof(ScriptableObject));
        foreach (VisualItem item in items)
        {
            AllVisualItems.Add(item);
        }
    }

    #region Currency

    public void ChangeCurrencyAmount(int amount)
    {
        signalBus.Fire(new OnCurrencyChangedSignal());
        playerInventory.ChangeCurrencyAmount(amount);
    }
    private void OnJobExecuted(OnJobExcecutedSignal signal)
    {
        ChangeCurrencyAmount(signal.Job.RewardAmount);
    }

    #endregion
    public bool HasItem(Item item)
    {
        return item.Quantity > 0;
    }

    public void RefreshAvailableItems()
    {
        availableItems = new List<VisualItem>(AllVisualItems);
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
