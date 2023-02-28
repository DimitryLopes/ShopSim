using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField]
    private AudioClip buttonClip;
    [SerializeField]
    private AudioSource audioSource;

    public override void InstallBindings()
    {
        AudioManager audioManager = new AudioManager(audioSource, buttonClip);
        Container.Bind<AudioManager>().FromInstance(audioManager).AsSingle();
    }
}
