using UnityEngine;
using UnityEngine.UI;

public class UIExitButon : Button
{
    private void Awake()
    {
        onClick.AddListener(Quit);
    }

    private void OnDestroy()
    {
        onClick.RemoveListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
