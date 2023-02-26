using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyItemScreen : IUIScreen
{
    [Inject]
    private PlayerManager playerManager;

    [SerializeField]
    private TextMeshProUGUI itemNameText;
    [SerializeField]
    private TextMeshProUGUI itemCostText;
    [SerializeField]
    private Image visualItemDisplay;
    [SerializeField]
    private Image itemTypeIcon;
    [SerializeField]
    private Button buyButton;

    private VisualItem item;

    protected override void SubscribeListeners()
    {
        base.SubscribeListeners();
        buyButton.onClick.AddListener(BuyItem);
    }

    protected override void UnsubscribeListeners()
    {
        base.UnsubscribeListeners();
        buyButton.onClick.RemoveAllListeners();
    }

    public void SetUp(VisualItem item)
    {
        this.item = item;
        itemCostText.text = item.Price.ToString();
        visualItemDisplay.sprite = item.DisplayableItem;
        itemNameText.text = item.Name;
    }

    protected override void DoHideAnimation()
    {
        transform.LeanScale(Vector3.zero, animationDuration).setEase(ease).setOnComplete(Close);
    }

    protected override void DoShowAnimation()
    {
        transform.LeanScale(Vector3.one, animationDuration).setEase(ease).setOnComplete(EnableButtons);
    }

    private void BuyItem()
    {
        PlayerInventory inventory = playerManager.Inventory;
        bool canBuy = inventory.HasEnoughCurrency(item.Price);
        if (canBuy)
        {
            OnPurchaseSucess(inventory);
            return;
        }
        //OnPurchaseFail() floating text here, maybe?
    }

    private void OnPurchaseSucess(PlayerInventory inventory)
    {
        inventory.RemoveCurrency(item.Price);
        inventory.AddItem(item);
        Hide();
    }
}
