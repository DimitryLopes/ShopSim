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

    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Button SellItemsButton;
    [SerializeField]
    private Button updateMannequinsButton;

    protected override void SubscribeListeners()
    {
        base.SubscribeListeners();
        updateMannequinsButton.onClick.AddListener(RefreshMannequins);
    }

    public void SetUp(string text)
    {
        dialogueText.text = text;
    }

    public void RefreshMannequins()
    {
        worldManager.RefreshMannequins();
    }
}
