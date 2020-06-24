using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameValue;
    [SerializeField]
    private Image avatarHolder;
    [SerializeField]
    private Image colorHolder;

    public void SaveSettings()
    {
        PlayerProfile.Instance.SetPlayerName(nameValue.text);
        PlayerProfile.Instance.SetPlayerAvatar(avatarHolder.sprite);
        PlayerProfile.Instance.SetPlayerColor(colorHolder.color);
    }

    public void UpdateSettings()
    {
        nameValue.text = PlayerProfile.Instance.GetPlayerName();
        avatarHolder.sprite = PlayerProfile.Instance.GetPlayerAvatar();
        colorHolder.color = PlayerProfile.Instance.GetPlayerColor();
    }
}
