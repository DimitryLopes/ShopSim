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
    private ItemManager itemManager;

    [SerializeField]
    private TextMeshProUGUI currencyAmountText;
    [SerializeField]
    private float shakeAnimationDuration;
    [SerializeField]
    private float shakeAnimationDelay;
    [SerializeField]
    private float shakeItensity;

    private PlayerInventory inventory;
    private bool isShaking;

    private void OnEnable()
    {
        signalBus.Subscribe<OnCurrencyChangedSignal>(OnCurrencyAmontChanged);
        signalBus.Subscribe<OnPurchaseFailSignal>(DoMissingCurrencyAnimation);
    }
    private void OnDisable()
    {
        signalBus.Unsubscribe<OnCurrencyChangedSignal>(OnCurrencyAmontChanged);
        signalBus.Unsubscribe<OnPurchaseFailSignal>(DoMissingCurrencyAnimation);
    }

    private void Start()
    {
        inventory = itemManager.Inventory;
        OnCurrencyAmontChanged();
    }

    private void OnCurrencyAmontChanged()
    {
        currencyAmountText.text = inventory.CurrencyAmount.ToString();
    }

    public void DoMissingCurrencyAnimation()
    {
        if (!isShaking)
        {
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        isShaking = true;
        currencyAmountText.color = Color.red;
        Vector3 startPos = transform.position;
        float animationTimer = 0;
        float delayTimer = 0;
        while(animationTimer < shakeAnimationDuration)
        {
            animationTimer += Time.deltaTime;
            delayTimer += Time.deltaTime;
            yield return null;
            if(delayTimer >= shakeAnimationDelay) 
            {
                Vector3 shakePos = Random.insideUnitCircle * Time.deltaTime * shakeItensity;
                transform.position = startPos + shakePos;
                delayTimer = 0;
            }
        }
        isShaking = false;
        transform.position = startPos;
        currencyAmountText.color = Color.white;
    }
}
