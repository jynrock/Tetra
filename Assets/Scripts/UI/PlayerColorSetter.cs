using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorSetter : MonoBehaviour
{
    public void SetPlayerColor()
    {
        PlayerProfile.Instance.setPlayerColor(GetComponent<Image>().color);
    }
}
