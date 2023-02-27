using UnityEngine;
using Zenject;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uiManager;

    public void Interact()
    {
        DialogueScreen screen = uiManager.GetScreen(ScreenType.DialogueScreen) as DialogueScreen;
        screen.SetUp("Welcome to my generic shop! make yourself at home, my home");
        screen.Show();
    }
}
