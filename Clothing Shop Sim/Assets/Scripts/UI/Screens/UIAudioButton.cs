using Zenject;
using UnityEngine.UI;
using System;
using UnityEngine;

public class UIAudioButton : Button
{
    [Inject]
    private AudioManager audioManager;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        audioManager.PlayButtonAudio();
    }
}
