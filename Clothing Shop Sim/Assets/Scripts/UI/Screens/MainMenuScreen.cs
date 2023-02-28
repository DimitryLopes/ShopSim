using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuScreen : UISlidingScreen
{
    [Inject]
    private WorldManager worldManager;

    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button optionButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Transform mainMenuContainer;
    [SerializeField]
    private Transform optionContainer;

    private void Start()
    {
        exitButton.onClick.AddListener(OnExitButtonClicked);
        playButton.onClick.AddListener(OnPlayButtonClicked);
        optionButton.onClick.AddListener(OnOptionButtonClicked);
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        Hide();
        worldManager.ActivateWorld();
    }

    private void OnOptionButtonClicked()
    {
        optionContainer.gameObject.SetActive(true);
        mainMenuContainer.gameObject.SetActive(false);
    }

    private void OnBackButtonClicked()
    {
        optionContainer.gameObject.SetActive(false);
        mainMenuContainer.gameObject.SetActive(true);

    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
