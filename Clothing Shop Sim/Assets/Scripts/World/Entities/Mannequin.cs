using UnityEngine;
using Zenject;

public class Mannequin : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    private VisualItemView itemView;

    public VisualItem Item { get; private set; }

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
}
