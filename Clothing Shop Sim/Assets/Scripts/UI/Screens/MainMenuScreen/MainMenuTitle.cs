using TMPro;
using UnityEngine;
using Zenject;

public class MainMenuTitle : MonoBehaviour
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private TextWriter textWritter;
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    private UILTScaleAnimation scaleAnimation;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private string text;
    [SerializeField]
    private float textAnimationCharDelay;

    bool animationFinished;

    private void Awake()
    {
        signalBus.Subscribe<OnFinishUITextAnimation>(OnAnimationFinish);
    }

    private void Start()
    {
        if (!animationFinished)
        {
            uiManager.AllowClick(false);
            DoAnimation();
        }
        animationFinished = true;
    }

    private void DoAnimation()
    {
        textWritter.Write(titleText, text, textAnimationCharDelay, true, ScreenType.MainMenuScreen);
    }

    private void OnAnimationFinish(OnFinishUITextAnimation signal)
    {
        if(signal.Screen == ScreenType.MainMenuScreen)
        {
            scaleAnimation.enabled = true;
        }
    }
}
