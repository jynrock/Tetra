using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class DialogueNode
{
    [SerializeField]
    private LocalizedString localizedName;
    [SerializeField]
    private LocalizedString localizedText;
    public Sprite icon;
    [SerializeField]
    private LocalizedAudioClip localizedAudioClip;
    public bool isNarration;

    public string LocalizedName()
    {
        if(!localizedName.IsEmpty)
        {
            var result = localizedName.GetLocalizedString();
            if (result.IsDone)
            {
                return result.Result;
            }
        }
        return null;
    }

    public string LocalizedText()
    {
        if(!localizedText.IsEmpty)
        {
            var result = localizedText.GetLocalizedString();
            if (result.IsDone)
            {
                return result.Result;
            }
        }
        return null;
    }

    public AudioClip LocalizedAudioClip()
    {
        if(!localizedAudioClip.IsEmpty)
        {
            var result = localizedAudioClip.LoadAssetAsync();
            if (result.IsDone)
            {
                return result.Result;
            }
        }
        return null;
    }
}
