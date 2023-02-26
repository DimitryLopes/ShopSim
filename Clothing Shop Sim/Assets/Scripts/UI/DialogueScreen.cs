using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DialogueScreen : IUIScreen
{
    [SerializeField]
    protected Transform startPosition;
    [SerializeField]
    protected Transform endPosition;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Transform screenTransform;
    [SerializeField]
    private Button SellItemsButton;


    protected override void DoShowAnimation()
    {
        screenTransform.LeanMoveLocalY(endPosition.localPosition.y, animationDuration).setEase(ease).setOnComplete(EnableButtons);
    }

    protected override void DoHideAnimation()
    {
        screenTransform.LeanMoveLocalY(startPosition.localPosition.y, animationDuration).setEase(ease).setOnComplete(Close);
    }

    public void SetUp(string text)
    {
        dialogueText.text = text;
    }
}
