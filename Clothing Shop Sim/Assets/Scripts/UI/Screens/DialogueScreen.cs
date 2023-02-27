using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DialogueScreen : UISlidingScreen
{
    [Inject]
    private WorldManager worldManager;
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Button sellItemsButton;
    [SerializeField]
    private Button updateMannequinsButton;

    protected override void OnAwake()
    {
        base.OnAwake();
        updateMannequinsButton.onClick.AddListener(RefreshMannequins);
        sellItemsButton.onClick.AddListener(ShowInventoryScreen);
    }

    public void SetUp(string text)
    {
        dialogueText.text = text;
    }

    private void ShowInventoryScreen()
    {
        Hide();
        InventoryScreen screen = (InventoryScreen)uiManager.GetScreen(ScreenType.InventoryScreen);
        screen.Show();
    }

    public void RefreshMannequins()
    {
        worldManager.RefreshMannequins();
    }
}
