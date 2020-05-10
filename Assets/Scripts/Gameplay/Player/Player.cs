using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public string playerName;
    public List<Card> hand;
    public List<Card> playedCards;
    public Color playerColor;
    public bool hasPlayedCard;
    public bool hasUsedAbility;

    [SerializeField]
    protected PlayerEvent endTurnEvent;
    [SerializeField]
    protected CardListDirectionEvent cardAttackEvent;

    public void SetupHand()
    {
        foreach(Card c in hand)
        {
            c.SetOriginalOwner(this);
        }
    }

    public abstract void OnPlayCard(CardTilePlayerEventData data);

    public IEnumerator HandleCombatPhase()
    {
        yield return null;
        for(int i = playedCards.Count - 1; i >= 0; i--)
        {
            Card card = playedCards[i];
            if(card.currentOwner == this)
            {
                Dictionary<Card, CardDirection> cardsToAttack = CardUtility.GetCardsToAttack(card, this);
                if(cardsToAttack.Count > 0)
                {
                    cardAttackEvent.Raise(new CardListDirectionEventData(card, cardsToAttack));
                }
            }
        }

        endTurnEvent.Raise(this);
    }

    public void OnStartPlayerTurn(Player player)
    {
        if(player == this)
        {
            hasPlayedCard = false;
            hasUsedAbility = false;
            if (hand.Count > 0)
            {
                StartCoroutine(TakeTurn());
            }
            else
            {
                StartCoroutine(HandleCombatPhase());
            }
        }
    }

    protected abstract IEnumerator TakeTurn();
}
