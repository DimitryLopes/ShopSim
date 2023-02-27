using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyItemScreen : UIScreen
{
    [Inject]
    private ItemManager itemManager;

    [SerializeField]
    private TextMeshProUGUI itemNameText;
    [SerializeField]
    private TextMeshProUGUI itemCostText;
    [SerializeField]
    private Image visualItemDisplay;
    [SerializeField]
    private UIItemView itemTypeIcon;
    [SerializeField]
    private Button buyButton;

    private VisualItem item;

    protected override void OnAwake()
    {
        base.OnAwake();
        buyButton.onClick.AddListener(BuyItem);
    }

    protected override void OnScreenDestroyed()
    {
        base.OnScreenDestroyed();
        buyButton.onClick.RemoveAllListeners();
    }

    public void SetUp(VisualItem item)
    {
        this.item = item;
        itemCostText.text = item.Price.ToString();
        visualItemDisplay.sprite = item.DisplayableItem;
        Sprite itemIconSprite = item.GetSpriteIcon();
        itemTypeIcon.DisplayItem(itemIconSprite);
        itemNameText.text = item.Name;
    }

    protected override void OnAfterHide()
    {
        transform.LeanScale(Vector3.zero, animationDuration).setEase(ease).setOnComplete(Close);
    }

    protected override void OnBeforeShow()
    {
        transform.LeanScale(Vector3.one, animationDuration).setEase(ease).setOnComplete(EnableButtons);
    }

    private void BuyItem()
    {
        PlayerInventory inventory = itemManager.Inventory;
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
