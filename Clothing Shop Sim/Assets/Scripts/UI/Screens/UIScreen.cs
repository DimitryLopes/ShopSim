using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public abstract class UIScreen : MonoBehaviour 
{
    [Inject]
    private PlayerManager playerManager;
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    protected float animationDuration;
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    protected LeanTweenType ease;

    bool isShown;

    private void Awake()
    {
        SubscribeListeners();
    }

    private void OnDestroy()
    {
        UnsubscribeListeners();
    }

    protected virtual void SubscribeListeners()
    {
        closeButton.onClick.AddListener(Hide);
    }

    protected virtual void UnsubscribeListeners()
    {
        closeButton.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        if (!isShown)
        {
            DisableButtons();
            gameObject.SetActive(true);
            isShown = true;
            playerManager.AllowPlayerActions(false);
            DoShowAnimation();
        }
    }

    public void Hide()
    {
        if (isShown)
        {
            playerManager.AllowPlayerActions(true);
            isShown = false;
            DoHideAnimation();
        }
    }

    protected void DisableButtons()
    {
        uiManager.AllowClick(false);
    }

    protected void EnableButtons()
    {
        uiManager.AllowClick(true);
    }

    protected virtual void Close()
    {
        gameObject.SetActive(false);
    }

    protected abstract void DoShowAnimation();
    protected abstract void DoHideAnimation();
}
