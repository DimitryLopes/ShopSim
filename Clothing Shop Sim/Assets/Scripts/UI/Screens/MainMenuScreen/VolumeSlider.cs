using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class VolumeSlider : MonoBehaviour
{
    [Inject]
    protected AudioManager audioManager;

    [SerializeField]
    private Slider slider;

    private void Start()
    {
        slider.onValueChanged.AddListener(AdjustVolume);
    }

    protected abstract void AdjustVolume(float volume);
}
