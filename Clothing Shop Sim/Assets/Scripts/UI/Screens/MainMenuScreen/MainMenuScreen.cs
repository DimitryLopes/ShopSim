using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuScreen : UISlidingScreen
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private WorldManager worldManager;

    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button optionButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Transform mainMenuContainer;
    [SerializeField]
    private Transform optionContainer;
    [SerializeField]
    private Transform buttonsContainer;
    [SerializeField]
    private float enableButtonsDelay;

    protected override void OnAwake()
    {
        signalBus.Subscribe<OnFinishUITextAnimation>(OnFinishUITextAnimation);
        playButton.onClick.AddListener(OnPlayButtonClicked);
        optionButton.onClick.AddListener(OnOptionButtonClicked);
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnEnable()
    {
        worldManager.SetListenerState(false);
    }

    protected void OnDisable()
    {
        worldManager.SetListenerState(true);
    }

    private void OnPlayButtonClicked()
    {
        Hide();
        worldManager.SetWorldState(true);
    }

    private void OnOptionButtonClicked()
    {
        optionContainer.gameObject.SetActive(true);
        mainMenuContainer.gameObject.SetActive(false);
    }

    private void OnFinishUITextAnimation(OnFinishUITextAnimation signal)
    {
        if (signal.Screen == ScreenType.MainMenuScreen)
        {
            DoButtonsAnimation();
        }
    }
    
    protected override void OnAfterShow()
    {
        base.OnAfterShow();
        worldManager.SetWorldState(false);
    }

    private void OnBackButtonClicked()
    {
        optionContainer.gameObject.SetActive(false);
        mainMenuContainer.gameObject.SetActive(true);
    }

    private void DoButtonsAnimation()
    {
        StartCoroutine(ShowButtons());
    }

    private IEnumerator ShowButtons()
    {
        int index = 0;
        float timer = enableButtonsDelay;
        UILTScaleAnimation[] anims = buttonsContainer.GetComponentsInChildren<UILTScaleAnimation>();
        while (index < anims.Length) 
        {
            timer -= Time.deltaTime;
            yield return null;
            if(timer <= 0)
            {
                anims[index].enabled = true;
                index++;
                timer = enableButtonsDelay;
            }
        }

        uiManager.AllowClick();
    }
}
