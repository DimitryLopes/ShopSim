using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uiManager;

    public void Interact()
    {
        DialogueScreen screen = uiManager.GetScreen(ScreenType.DialogueScreen) as DialogueScreen;
        screen.SetUp("hello I'm placeholder");
        screen.Show();
    }
}
