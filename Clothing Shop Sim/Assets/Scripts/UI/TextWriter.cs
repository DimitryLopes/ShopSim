using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TextWriter : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;
    [Inject]
    private SignalBus signalBus;

    [SerializeField]
    private AudioClip typeSFX;

    public void Write(TextMeshProUGUI uiText, string text, float charDelay, bool playSound, ScreenType type)
    {
        StartCoroutine(WriteText(uiText, text, charDelay, playSound, type));
    }

    private IEnumerator WriteText(TextMeshProUGUI currentText, string text, float charDelay, bool playSound, ScreenType type)
    {
        int index = 0;
        float timer = charDelay;
        while(currentText.text.Length != text.Length)
        {
            yield return null;
            timer -= Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                charDelay = 0;
                playSound = false;
            }

            if (timer <= 0)
            {
                currentText.text = text.Substring(0, index);
                timer = charDelay;
                index++;
                if (playSound)
                {
                    audioManager.PlayAudio(typeSFX);
                }
            }
        }

        signalBus.Fire(new OnFinishUITextAnimationSignal(type));
    }
}
