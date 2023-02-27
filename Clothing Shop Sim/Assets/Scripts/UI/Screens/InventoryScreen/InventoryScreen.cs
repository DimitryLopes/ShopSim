using System.Collections;
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
    private Button equipButton;

    private InventoryItemView selectedItemView;

    private List<InventoryItemView> itemViews = new List<InventoryItemView>();

    protected override void OnAwake()
    {
        base.OnAwake();
        sellButton.onClick.AddListener(SellItem);
        equipButton.onClick.AddListener(EquipItem);
        signalBus.Subscribe<OnInventoryItemSelectedSignal>(SelectItem);
    }

    #region Show/Hide
    protected override void OnScreenDestroyed()
    {
        base.OnScreenDestroyed();
        sellButton.onClick.RemoveAllListeners();
        equipButton.onClick.RemoveAllListeners();
    }

    protected override void OnBeforeShow()
    {
        PlayerInventory inventory = itemManager.Inventory;
        //reminder to try find a better way
        foreach(VisualItem item in inventory.VisualItems)
        {
            foreach(InventoryItemView view in itemViews)
            {
                if(view.IsActive == false)
                {
                    view.DisplayItem(item);
                    continue;
                }
            }
            InventoryItemView newItemView = inventoryItemViewFactory.Create(item);
            itemViews.Add(newItemView);
            newItemView.Deselect();
        }
        //
        base.OnBeforeShow();
    }

    protected override void Close()
    {
        foreach (InventoryItemView view in itemViews)
        {
            view.Hide();
        }
        base.Close();
    }
    #endregion

    private void SellItem()
    {

    }

    private void EquipItem()
    {

    }

    private void SelectItem(OnInventoryItemSelectedSignal signal)
    {
        if (selectedItemView != null)
        {
            selectedItemView.Deselect();
        }
        signal.ItemView.Select();
    }
}