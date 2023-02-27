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
        OnAwake();
    }

    private void OnDestroy()
    {
        OnScreenDestroyed();
    }

    protected virtual void OnAwake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    protected virtual void OnScreenDestroyed()
    {
        closeButton.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        if (!isShown)
        {
            DisableButtons();
            isShown = true;
            playerManager.AllowPlayerActions(false);
            OnBeforeShow();
            gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (isShown)
        {
            playerManager.AllowPlayerActions(true);
            isShown = false;
            OnAfterHide();
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

    protected abstract void OnBeforeShow();
    protected abstract void OnAfterHide();
}
