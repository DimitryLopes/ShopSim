using UnityEngine;
using Zenject;

public class Carpet : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uIManager;

    public void Interact()
    {
        WorkScreen screen = (WorkScreen)uIManager.GetScreen(ScreenType.WorkScreen);
        screen.Show();
    }
}
