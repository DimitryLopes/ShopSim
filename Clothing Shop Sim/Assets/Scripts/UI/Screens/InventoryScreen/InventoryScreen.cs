using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryScreen : UISlidingScreen
{
    [Inject]
    private ItemManager itemManager;
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private InventoryItemView.Factory inventoryItemViewFactory;

    [SerializeField]
    private Transform itemViewsContainer;
    [SerializeField]
    private Button sellButton;
    [SerializeField]
    private Transform equipButtonContainer;

    private InventoryItemView selectedItemView;

    private List<InventoryItemView> itemViews = new List<InventoryItemView>();

    protected override void OnAwake()
    {
        base.OnAwake();
        sellButton.onClick.AddListener(SellItem);
        signalBus.Subscribe<OnInventoryItemSelectedSignal>(SelectItem);
    }

    #region Show/Hide
    protected override void OnScreenDestroyed()
    {
        base.OnScreenDestroyed();
        sellButton.onClick.RemoveAllListeners();
        signalBus.Unsubscribe<OnInventoryItemSelectedSignal>(SelectItem);
    }

    protected override void OnBeforeShow()
    {
        PlayerInventory inventory = itemManager.Inventory;
        foreach(VisualItem item in inventory.VisualItems)
        {
            bool foundDisplay = false;
            foreach(InventoryItemView view in itemViews)
            {
                if(view.IsActive == false)
                {
                    view.DisplayItem(item);
                    foundDisplay = true;
                    break;
                }
            }
            if (!foundDisplay)
            {
                InventoryItemView newItemView = inventoryItemViewFactory.Create(item);
                itemViews.Add(newItemView);
                newItemView.transform.SetParent(itemViewsContainer);
                newItemView.Deselect();
            }
        }

        base.OnBeforeShow();
    }

    public void SetUp(bool isStore)
    {
        sellButton.gameObject.SetActive(isStore);
        equipButtonContainer.gameObject.SetActive(!isStore);
    }

    protected override void Close()
    {
        if (selectedItemView != null)
        {
            selectedItemView.Deselect();
        }

        foreach (InventoryItemView view in itemViews)
        {
            view.Hide();

        }
        base.Close();
    }
    #endregion

    private void SellItem()
    {
        if (selectedItemView != null)
        {
            itemManager.RemoveItem(selectedItemView.Item);
            itemManager.ChangeCurrencyAmount(selectedItemView.Item.Price);
            selectedItemView.gameObject.SetActive(false);
            selectedItemView = null;
        }
    }

    private void SelectItem(OnInventoryItemSelectedSignal signal)
    {
        if (selectedItemView != null)
        {
            selectedItemView.Deselect();
        }

        if (signal.ItemView != null)
        {
            signal.ItemView.Select();
            selectedItemView = signal.ItemView;
        }
        else
        {
            selectedItemView = null;
        }
    }
}
