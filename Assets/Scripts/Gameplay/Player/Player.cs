using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public string playerName;
    public List<BattleCard> hand;
    public List<BattleCard> playedCards;
    public Color playerColor;
    public bool hasPlayedCard;
    public bool hasUsedAbility;

    [SerializeField]
    protected PlayerEvent endTurnEvent;
    [SerializeField]
    protected BattlecardListDirectionEvent cardAttackEvent;

    public abstract void SetupHand();

    public abstract void OnPlayCard(BattlecardTilePlayerEventData data);

    private bool awaitingAnimations;

    public void SetData(string name, Color color, List<BattleCard> hand)
    {
        this.playerName = name;
        this.playerColor = color;
        this.hand = hand;
    }

    public void StartCombatPhase()
    {
        StartCoroutine(HandleCombatPhase());
    }

    public IEnumerator HandleCombatPhase()
    {
        bool attacked = false;
        yield return null;
        for(int i = playedCards.Count - 1; i >= 0; i--)
        {
            BattleCard card = playedCards[i];
            if(card.currentOwner == this)
            {
                Dictionary<BattleCard, CardDirection> cardsToAttack = CardUtility.GetCardsToAttack(card, this);
                if(cardsToAttack.Count > 0)
                {
                    cardAttackEvent.Raise(new BattlecardListDirectionEventData(card, cardsToAttack));
                    yield return new WaitForSeconds(0.25f * cardsToAttack.Count);
                    attacked = true;
                }
            }
        }

        if (attacked)
        {
            awaitingAnimations = true;
        }

        while(awaitingAnimations)
        {
            yield return null;
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

    public void OnEndAwaitAnimations(Player player)
    {
        if (player == this)
        {
            awaitingAnimations = false;
        }
    }

    protected abstract IEnumerator TakeTurn();
}
