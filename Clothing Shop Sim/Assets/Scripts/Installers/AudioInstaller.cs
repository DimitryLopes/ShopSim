using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField]
    private AudioClip buttonClip;
    [SerializeField]
    private AudioSource bgmSource;
    [SerializeField]
    private AudioSource sfxSource;

    public override void InstallBindings()
    {
        AudioManager audioManager = new AudioManager(sfxSource, bgmSource, buttonClip);
        Container.Bind<AudioManager>().FromInstance(audioManager).AsSingle();
    }
}
