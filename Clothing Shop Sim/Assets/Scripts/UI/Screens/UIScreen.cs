using UnityEngine;
using Zenject;
using UnityEngine.UI;

public abstract class UIScreen : MonoBehaviour 
{
    [Inject]
    private PlayerManager playerManager;
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private UIManager uiManager;

    [SerializeField, Header("Animation")]
    protected float animationDuration;
    [SerializeField]
    protected LeanTweenType ease;
    [SerializeField]
    protected Transform screenTransform;
    [SerializeField, Space]
    private Button closeButton;

    protected bool isFirstShow = true;
    public bool CanShow { get; private set; } = true;

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
        if (uiManager.CurrentOpenedScreen != this && CanShow)
        {
            CanShow = false;
            signalBus.Fire(new OnScreenOpenedSignal(this));
            DisableButtons();
            OnBeforeShow();
            playerManager.AllowPlayerActions(false);
            isFirstShow = false;
            gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (uiManager.CurrentOpenedScreen == this)
        {
            signalBus.Fire(new OnScreenClosedSignal(this));
            playerManager.AllowPlayerActions(true);
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
        CanShow = true;
    }

    protected abstract void OnBeforeShow();
    protected abstract void OnAfterHide();
}
