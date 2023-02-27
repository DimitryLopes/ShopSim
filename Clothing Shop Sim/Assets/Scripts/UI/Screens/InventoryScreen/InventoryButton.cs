using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryButton : MonoBehaviour
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    protected ItemManager itemManager;

    [SerializeField]
    private string toggledText;
    [SerializeField]
    private string untoggledText;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    protected VisualItem selectedItem;

    private void Awake()
    {
        signalBus.Subscribe<OnInventoryItemSelectedSignal>(ChangeState);
    }

    private void OnDestroy()
    {
        signalBus.Unsubscribe<OnInventoryItemSelectedSignal>(ChangeState);
    }

    private void ChangeState(OnInventoryItemSelectedSignal signal)
    {
        button.onClick.RemoveAllListeners();
        bool hasItemSelected = signal.ItemView != null;
        if (hasItemSelected)
        {
            if (signal.ItemView.Item.Equipped)
            {
                buttonText.text = toggledText;
                button.onClick.AddListener(OnToggledClick);
            }
            else
            {
                buttonText.text = untoggledText;
                button.onClick.AddListener(OnUntoggledClick);
            }

            selectedItem = signal.ItemView.Item;
        }
        gameObject.SetActive(hasItemSelected);
    }

    private void OnToggledClick()
    {
        itemManager.Inventory.Unequip(selectedItem.Type);
    }

    private void OnUntoggledClick()
    {
        itemManager.Inventory.EquipItem(selectedItem);
    }
}
