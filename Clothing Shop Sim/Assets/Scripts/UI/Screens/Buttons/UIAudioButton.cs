using Zenject;
using UnityEngine.UI;

public class UIAudioButton : Button
{
    [Inject]
    private AudioManager audioManager;

    private void Awake()
    {
        onClick.AddListener(PlaySound);
    }

    private void OnDestroy()
    {
        onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        audioManager.PlayButtonAudio();
    }
}
