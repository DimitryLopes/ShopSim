using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TutorialScreen : UIScalingScreen
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private TextWriter textWriter;

    [SerializeField]
    private string tutorialMessage;
    [SerializeField]
    private float textAnimationDelay;
    [SerializeField]
    private TextMeshProUGUI tutorialText;

    private void OnEnable()
    {
        signalBus.Subscribe<OnFinishUITextAnimationSignal>(ShowContinueButton);
    }

    private void OnDisable()
    {
        signalBus.Unsubscribe<OnFinishUITextAnimationSignal>(ShowContinueButton);
    }

    protected override void OnAfterShow()
    {
        base.OnAfterShow();
        textWriter.Write(tutorialText, tutorialMessage, textAnimationDelay, true, ScreenType.TutorialScreen);
    }

    protected override void OnAfterHide()
    {
        //show only once
        gameObject.SetActive(false);
    }

    private void ShowContinueButton(OnFinishUITextAnimationSignal signal)
    {
        if(signal.Screen == ScreenType.TutorialScreen)
        {
            closeButton.gameObject.SetActive(true);
        }
    }
}
