using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyItemScreen : UIScalingScreen
{
    [Inject]
    private SignalBus signalBus;
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
        visualItemDisplay.sprite = item.MannequinDisplayable;
        Sprite itemIconSprite = item.GetSpriteIcon();
        itemTypeIcon.DisplayItem(itemIconSprite);
        itemNameText.text = item.Name;
    }

    private void BuyItem()
    {
        PlayerInventory inventory = itemManager.Inventory;
        bool canBuy = inventory.HasEnoughCurrency(item.Price);
        if (canBuy)
        {
            OnPurchaseSucess();
            return;
        }
        //OnPurchaseFail() floating text here, maybe?
    }

    private void OnPurchaseSucess()
    {
        itemManager.ChangeCurrencyAmount(-item.Price);
        itemManager.AddItem(item);
        signalBus.Fire(new OnItemBoughtSignal(item));
        Hide();
    }
}
