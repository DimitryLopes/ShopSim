using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CurrencyDisplay : MonoBehaviour
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private PlayerManager playerManager;

    [SerializeField]
    private TextMeshProUGUI currencyAmountText;
    private PlayerInventory inventory;

    private void OnEnable()
    {
        signalBus.Subscribe<OnCurrencyChangedSignal>(OnCurrencyAmontChanged);
    }
    private void OnDisable()
    {
        signalBus.Subscribe<OnCurrencyChangedSignal>(OnCurrencyAmontChanged);
    }

    private void Start()
    {
        inventory = playerManager.Inventory;
    }

    private void OnCurrencyAmontChanged()
    {
        currencyAmountText.text = inventory.CurrencyAmount.ToString();
    }
}
