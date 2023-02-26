using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public abstract class IUIScreen : MonoBehaviour 
{
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    protected Transform startPosition;
    [SerializeField]
    protected Transform endPosition;
    [SerializeField]
    protected float animationDuration;
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    protected LeanTweenType ease;

    bool isShown;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    public void Show()
    {
        if (!isShown)
        {
            DisableButtons();
            gameObject.SetActive(true);
            isShown = true;
            DoShowAnimation();
        }
    }

    public void Hide()
    {
        if (isShown)
        {
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

    protected void Close()
    {
        gameObject.SetActive(false);
    }

    protected abstract void DoShowAnimation();
    protected abstract void DoHideAnimation();
}
