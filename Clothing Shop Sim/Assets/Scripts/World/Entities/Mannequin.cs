using UnityEngine;
using Zenject;

public class Mannequin : MonoBehaviour, IInteractable
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    private WorldItemView itemView;

    public VisualItem Item { get; private set; }

    private void OnEnable()
    {
        signalBus.Subscribe<OnItemBoughtSignal>(OnItemBought);
    }
    private void OnDisable()
    {
        signalBus.Unsubscribe<OnItemBoughtSignal>(OnItemBought);
    }

    //I need a better name for this
    public void Dress(VisualItem item)
    {
        Item = item;
        itemView.DisplayItem(item);
    }

    public void Interact()
    {
        if (Item != null)
        {
            BuyItemScreen screen = uiManager.GetScreen(ScreenType.BuyItemScreen) as BuyItemScreen;
            screen.SetUp(Item);
            screen.Show();
        }
    }

    public void OnItemBought(OnItemBoughtSignal signal)
    {
        if(signal.Item == Item)
        {
            Dress(null);
        }
    }
}
