using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider effectVolumeSlider;
    [SerializeField]
    private Slider dialogueVolumeSlider;
    
    public void PopulatePanel()
    {
        musicVolumeSlider.value = AudioManager.Instance.GetMusicVolume();
        effectVolumeSlider.value = AudioManager.Instance.GetEffectVolume();
        dialogueVolumeSlider.value = AudioManager.Instance.GetDialogueVolume();
    }

    public void SetMusicVolume()
    {
        AudioManager.Instance.SetMusicVolume(musicVolumeSlider.value);
    }

    public void SetEffectVolume()
    {
        AudioManager.Instance.SetEffectVolume(effectVolumeSlider.value);
    }

    public void SetDialogueVolume()
    {
        AudioManager.Instance.SetDialogueVolume(dialogueVolumeSlider.value);
    }
}
