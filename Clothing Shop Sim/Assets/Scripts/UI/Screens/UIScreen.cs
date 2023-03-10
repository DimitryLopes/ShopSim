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
    private AudioManager audioManager;
    [Inject]
    private UIManager uiManager;

    [SerializeField, Header("Sound")]
    private AudioClip openAudioClip;
    [SerializeField]
    private AudioClip closeAudioClip;

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
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(Hide);
            closeButton.onClick.AddListener(PlayCloseAudio);
        }
    }

    protected virtual void OnScreenDestroyed()
    {
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
        }
    }

    public void Show()
    {
        if (uiManager.CurrentOpenedScreen != this && CanShow)
        {
            CanShow = false;
            DisableButtons();
            OnBeforeShow();
            PlayAudio(openAudioClip);
            playerManager.AllowPlayerActions(false);
            gameObject.SetActive(true);
            signalBus.Fire(new OnScreenOpenedSignal(this));
            isFirstShow = false;
        }
    }

    public void Hide()
    {
        if (uiManager.CurrentOpenedScreen == this)
        {
            OnBeforeHide();
            playerManager.AllowPlayerActions(true);
            signalBus.Fire(new OnScreenClosedSignal(this));
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        audioManager.PlayAudio(clip);
    }

    private void PlayCloseAudio()
    {
        audioManager.PlayAudio(closeAudioClip);
    }

    protected void DisableButtons()
    {
        uiManager.AllowClick(false);
    }

    protected virtual void OnAfterShow()
    {
        uiManager.AllowClick(true);
    }

    protected virtual void Close()
    {
        gameObject.SetActive(false);
        CanShow = true;
    }

    protected abstract void OnBeforeShow();
    protected abstract void OnBeforeHide();
}
