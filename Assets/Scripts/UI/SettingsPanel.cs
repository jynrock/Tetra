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
        musicVolumeSlider.value = SettingsManager.Instance.GetMusicVolume();
        effectVolumeSlider.value = SettingsManager.Instance.GetEffectVolume();
        dialogueVolumeSlider.value = SettingsManager.Instance.GetDialogueVolume();
    }

    public void SetMusicVolume()
    {
        SettingsManager.Instance.SetMusicVolume(musicVolumeSlider.value);
    }

    public void SetEffectVolume()
    {
        SettingsManager.Instance.SetEffectVolume(effectVolumeSlider.value);
    }

    public void SetDialogueVolume()
    {
        SettingsManager.Instance.SetDialogueVolume(dialogueVolumeSlider.value);
    }
}
