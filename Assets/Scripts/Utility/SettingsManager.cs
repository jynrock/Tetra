using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private static SettingsManager _instance;
    public static SettingsManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    [SerializeField]
    private AudioSource dialogueSource;

    void Awake()
    {
        if (_instance == null || _instance != this)
        {
            _instance = this;
        }
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
}
