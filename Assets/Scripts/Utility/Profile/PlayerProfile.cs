using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    private static PlayerProfile _instance;
    public static PlayerProfile Instance { get {return _instance;} }
    private string playerName;
    private Sprite playerAvatar;
    private Color playerColor;
    private List<CardInstance> deck;
    private List<CardInstance> hand;
    private bool leftyMode;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public string GetPlayerName()
    {
        if(playerName == null || playerName == "")
        {
            playerName = "New Player";
        }
        return playerName;
    }

    public void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
    }

    public Sprite GetPlayerAvatar()
    {
        if(playerAvatar == null)
        {
            playerAvatar = GetDeck()[1].info.cardIcon;
        }
        return playerAvatar;
    }

    public void SetPlayerAvatar(Sprite _playerAvatar)
    {
        playerAvatar = _playerAvatar;
    }

    public Color GetPlayerColor()
    {
        if(playerColor == null || playerColor.a < 1)
        {
            playerColor = new Color(0, 0, 1, 1);
        }
        return playerColor;
    }

    public void SetPlayerColor(Color _playerColor)
    {
        playerColor = _playerColor;
    }

    public List<CardInstance> GetDeck()
    {
        if(this.deck == null || this.deck.Count == 0 )
        {
            SetDeck(Database.Instance.Card.defaultDeck);
        }
        return deck;
    }

    public void SetDeck(List<CardInstance> _deck)
    {
        deck = _deck;
    }

    public void AddToDeck(CardInstance cardInstance)
    {
        deck.Add(cardInstance);
    }

    public void RemoveFromDeck(CardInstance cardInstance)
    {
        deck.Remove(cardInstance);
    }

    public List<CardInstance> GetHand()
    {
        if(hand == null)
        {
            SetHand(GetDeck().Take(5).ToList());
        }
        return hand;
    }

    public bool AddToHand(CardInstance card)
    {
        if(hand.Count >= 5 || hand.Contains(card))
        {
            return false;
        }
        hand.Add(card);
        return true;
    }

    public bool RemoveFromHand(CardInstance card)
    {
        if(!hand.Contains(card))
        {
            return false;
        }
        hand.Remove(card);
        return true;
    }

    public void SetHand(List<CardInstance> _hand)
    {
        hand = _hand;
    }

    public List<CardInstance> GetCardsFromDeck(int num)
    {
        List<CardInstance> results = new List<CardInstance>();

        results = deck.Where(c => c.info.cardNumber == num).ToList();

        return results;
    }

    public List<CardInstance> GetCardsFromDeck(string name)
    {
        List<CardInstance> results = new List<CardInstance>();

        //TODO support localized string getting
        //results = deck.Where(c => c.info.cardName == name).ToList();

        return results;
    }

    public List<Sprite> GetAvailableAvatars()
    {
        List<Card> cardsInDeck = deck.Select(c => c.info).Distinct().ToList();
        List<Sprite> avatarsAvailable = cardsInDeck.Select(c => c.cardIcon).ToList();
        return avatarsAvailable;
    }

    public bool GetLeftyMode()
    {
        return leftyMode;
    }

    public void SetLeftyMode(bool newLeftyMode)
    {
        leftyMode = newLeftyMode;
    }
}
