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
    private Button backButton;
    [SerializeField]
    private Transform mainMenuContainer;
    [SerializeField]
    private Transform optionContainer;

    protected override void OnAwake()
    {
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
    
    protected override void OnAfterShow()
    {
        worldManager.SetWorldState(false);
    }

    private void OnBackButtonClicked()
    {
        optionContainer.gameObject.SetActive(false);
        mainMenuContainer.gameObject.SetActive(true);

    }
}
