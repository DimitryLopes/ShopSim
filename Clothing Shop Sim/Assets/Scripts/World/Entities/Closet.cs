using UnityEngine;
using Zenject;

public class Closet : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uiManager;

    public void Interact()
    {
        InventoryScreen screen = uiManager.GetScreen(ScreenType.InventoryScreen) as InventoryScreen;
        screen.SetUp(false);
        screen.Show();
    }
}
