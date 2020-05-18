using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    private static PlayerProfile _instance;
    public static PlayerProfile Instance { get {return _instance;} }
    public string playerName;
    public Sprite playerAvatar;
    public Color playerColor;
    public Card[] deck;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        if (playerName == null || playerName == "")
        {
            playerName = "New Player";
            playerColor = Color.blue;
        }
    }

    public string getPlayerName()
    {
        return this.playerName;
    }

    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    public Sprite getPlayerAvatar()
    {
        return this.playerAvatar;
    }

    public void setPlayerAvatar(Sprite playerAvatar)
    {
        this.playerAvatar = playerAvatar;
    }

    public Color getPlayerColor()
    {
        return this.playerColor;
    }

    public void setPlayerColor(Color playerColor)
    {
        this.playerColor = playerColor;
    }

    public Card[] getDeck()
    {
        return this.deck;
    }

    public void setDeck(Card[] deck)
    {
        this.deck = deck;
    }

}
