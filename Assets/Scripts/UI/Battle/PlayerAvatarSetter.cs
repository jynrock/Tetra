using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAvatarSetter : MonoBehaviour
{
    public void SetPlayerAvatar()
    {
        PlayerProfile.Instance.SetPlayerAvatar(GetComponent<Image>().sprite);
        GameObject.Find("AvatarPicker").GetComponent<AvatarPicker>().ClosePicker();
    }
}
