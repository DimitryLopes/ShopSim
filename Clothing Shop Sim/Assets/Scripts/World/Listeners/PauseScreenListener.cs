using UnityEngine;
using Zenject;

public class PauseScreenListener : MonoBehaviour
{
    [Inject]
    private UIManager uIManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen screen = (PauseScreen)uIManager.GetScreen(ScreenType.PauseScreen);
            screen.Show();
        }
    }
}
