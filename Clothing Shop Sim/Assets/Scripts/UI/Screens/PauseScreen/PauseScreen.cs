using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseScreen : UIScalingScreen
{
    [Inject]
    private UIManager uIManager;

    [SerializeField]
    private Button backToMainMenuButton;

    private void OnEnable()
    {
        backToMainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }

    private void OnDisable()
    {
        backToMainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnMainMenuButtonClicked()
    {
        UIScreen screen = uIManager.GetScreen(ScreenType.MainMenuScreen);
        screen.Show();
    }
}
