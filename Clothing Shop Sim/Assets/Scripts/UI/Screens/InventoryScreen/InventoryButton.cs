using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryButton : MonoBehaviour
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private AudioManager audioManager;
    [Inject]
    private ItemManager itemManager;

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
        signalBus.Subscribe<OnInventoryItemSelectedSignal>(OnItemSelected);
        signalBus.Subscribe<OnScreenOpenedSignal>(OnScreenOpened);
    }

    private void OnDestroy()
    {
        signalBus.Unsubscribe<OnInventoryItemSelectedSignal>(OnItemSelected);
        signalBus.Unsubscribe<OnScreenOpenedSignal>(OnScreenOpened);
    }

    private void OnItemSelected(OnInventoryItemSelectedSignal signal)
    {
        bool hasItemSelected = signal.ItemView != null;
        if (hasItemSelected)
        {
            bool toggled = signal.ItemView.Item.Equipped;
            ChangeState(toggled);
            selectedItem = signal.ItemView.Item;
        }
        gameObject.SetActive(hasItemSelected);
    }

    private void ChangeState(bool toggled)
    {
        button.onClick.RemoveAllListeners();
        if (toggled)
        {
            buttonText.text = toggledText;
            button.onClick.AddListener(OnToggledClick);
        }
        else
        {
            buttonText.text = untoggledText;
            button.onClick.AddListener(OnUntoggledClick);
        }
        button.onClick.AddListener(audioManager.PlayButtonAudio);
    }

    private void OnScreenOpened(OnScreenOpenedSignal signal)
    {
        if(signal.Screen is InventoryScreen)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnToggledClick()
    {
        itemManager.Inventory.Unequip(selectedItem.Type);
        ChangeState(false);
    }

    private void OnUntoggledClick()
    {
        itemManager.Inventory.EquipItem(selectedItem);
        ChangeState(true);
    }
}
