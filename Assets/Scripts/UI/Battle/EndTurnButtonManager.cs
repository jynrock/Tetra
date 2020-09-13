using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButtonManager : MonoBehaviour
{
    private Player humanPlayer;
    [SerializeField]
    private Button button;

    public void OnAnnouncePlayer(Player announcedPlayer)
    {
        humanPlayer = announcedPlayer;
    }

    public void OnPlayerTurnChange(Player currentPlayer)
    {
        if (currentPlayer == humanPlayer)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
