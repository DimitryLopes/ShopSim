using UnityEngine;
using Zenject;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    private string text;

    public void Interact()
    {
        DialogueScreen screen = uiManager.GetScreen(ScreenType.DialogueScreen) as DialogueScreen;
        screen.SetUp(text);
        screen.Show();
    }
}
