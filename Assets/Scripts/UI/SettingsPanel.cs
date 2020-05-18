using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameValue;
    [SerializeField]
    private Image avatarHolder;
    [SerializeField]
    private Image colorHolder;

    public void UpdateSettings()
    {
        nameValue.text = PlayerProfile.Instance.playerName;
        //avatarHolder.sprite = PlayerProfile.Instance.playerAvatar;
        colorHolder.color = PlayerProfile.Instance.playerColor != null ? PlayerProfile.Instance.playerColor : Color.white;
    }
}
