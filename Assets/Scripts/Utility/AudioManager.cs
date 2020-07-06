using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    private static AudioManager _instance;
    public static AudioManager Instance { get {return _instance;} }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    [SerializeField]
    private AudioSource dialogueSource;

    public void PlayMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        effectSource.Stop();
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void PlayDialogue(AudioClip clip)
    {
        dialogueSource.Stop();
        dialogueSource.clip = clip;
        dialogueSource.Play();
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetEffectVolume()
    {
        return effectSource.volume;
    }

    public float GetDialogueVolume()
    {
        return dialogueSource.volume;
    }

    public void SetMusicVolume(float newVol)
    {
        musicSource.volume = newVol;
    }

    public void SetEffectVolume(float newVol)
    {
        effectSource.volume = newVol;
    }

    public void SetDialogueVolume(float newVol)
    {
        dialogueSource.volume = newVol;
    }

    public void StopCurrentMusic()
    {
        musicSource.Stop();
    }

    public void StopCurrentEffect()
    {
        effectSource.Stop();
    }

    public void StopCurrentDialogue()
    {
        dialogueSource.Stop();
    }
}
