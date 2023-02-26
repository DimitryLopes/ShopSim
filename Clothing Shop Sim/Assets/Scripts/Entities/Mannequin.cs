using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Mannequin : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uiManager;

    private VisualItem item;

    public void Interact()
    {
        BuyItemScreen screen = uiManager.GetScreen(ScreenType.BuyItemScreen) as BuyItemScreen;
        screen.SetUp(item);
        screen.Show();
        Debug.Log("someone interacted with me, help, I'm Introvert");
    }
}
