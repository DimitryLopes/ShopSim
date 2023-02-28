using UnityEngine;
    
public class AudioManager 
{
    private AudioSource sfxSource;
    private AudioSource bgmSource;
    private AudioClip buttonClip;

    public AudioManager(AudioSource sfxSource, AudioSource bgmSource, AudioClip buttonClip)
    {
        this.sfxSource = sfxSource;
        this.bgmSource = bgmSource;
        this.buttonClip = buttonClip;
    }

    public void PlayButtonAudio()
    {
            sfxSource.PlayOneShot(buttonClip);
    }

    public void PlayAudio(AudioClip audioClip)
    {
        if (audioClip != null)
        {
            sfxSource.PlayOneShot(audioClip);
        }
    }

    public void ChangeBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayAudio(buttonClip);
    }
}
