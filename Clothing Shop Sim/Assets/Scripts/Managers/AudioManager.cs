using UnityEngine;

public class AudioManager 
{
    private AudioSource audioSource;
    private AudioClip buttonClip;

    public AudioManager(AudioSource source, AudioClip buttonClip)
    {
        audioSource = source;
        this.buttonClip = buttonClip;
    }

    public void PlayButtonAudio()
    {
            audioSource.PlayOneShot(buttonClip);
    }

    public void PlayAudio(AudioClip audioClip)
    {
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
