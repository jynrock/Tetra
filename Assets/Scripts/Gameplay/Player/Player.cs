using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public List<Card> hand;

    public List<Card> playedCards;
    public Color playerColor;

    [SerializeField]
    protected PlayerEvent endTurnEvent;
    [SerializeField]
    protected CardListDirectionEvent cardAttackEvent;

    protected bool hasMoved;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupHand()
    {
        foreach(Card c in hand)
        {
            c.SetOriginalOwner(this);
        }
    }

    public abstract void OnPlayCard(CardTilePlayerEventData data);

    protected IEnumerator HandleCombatPhase()
    {
        yield return null;
        for(int i = playedCards.Count - 1; i >= 0; i--)
        {
            Card card = playedCards[i];
            if(card.currentOwner == this)
            {
                Dictionary<Card, CardDirection> cardsToAttack = GetCardsToAttack(card);
                if(cardsToAttack.Count > 0)
                {
                    cardAttackEvent.Raise(new CardListDirectionEventData(card, cardsToAttack));
                }
            }
        }

        hasMoved = true;
        endTurnEvent.Raise(this);
    }

    // TODO: Surely there's a better way of handling this
    private Dictionary<Card, CardDirection> GetCardsToAttack(Card card)
    {
        Dictionary<Card, CardDirection> result = new Dictionary<Card, CardDirection>();

        if (card.arrows.topLeft.Value && card.tile.neighbors.topLeft != null && card.tile.neighbors.topLeft.card != null && card.tile.neighbors.topLeft.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.topLeft.card, CardDirection.topLeft);
        }
        if (card.arrows.top.Value && card.tile.neighbors.top != null && card.tile.neighbors.top.card != null && card.tile.neighbors.top.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.top.card, CardDirection.top);
        }
        if (card.arrows.topRight.Value && card.tile.neighbors.topRight != null && card.tile.neighbors.topRight.card != null && card.tile.neighbors.topRight.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.topRight.card, CardDirection.topRight);
        }
        if (card.arrows.right.Value && card.tile.neighbors.right != null && card.tile.neighbors.right.card != null && card.tile.neighbors.right.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.right.card, CardDirection.right);
        }
        if (card.arrows.bottomRight.Value && card.tile.neighbors.bottomRight != null && card.tile.neighbors.bottomRight.card != null && card.tile.neighbors.bottomRight.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.bottomRight.card, CardDirection.bottomRight);
        }
        if (card.arrows.bottom.Value && card.tile.neighbors.bottom != null && card.tile.neighbors.bottom.card != null && card.tile.neighbors.bottom.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.bottom.card, CardDirection.bottom);
        }
        if (card.arrows.bottomLeft.Value && card.tile.neighbors.bottomLeft != null && card.tile.neighbors.bottomLeft.card != null && card.tile.neighbors.bottomLeft.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.bottomLeft.card, CardDirection.bottomLeft);
        }
        if (card.arrows.left.Value && card.tile.neighbors.left != null && card.tile.neighbors.left.card != null && card.tile.neighbors.left.card.currentOwner != this)
        {
            result.Add(card.tile.neighbors.left.card, CardDirection.left);
        }

        return result;
    }

    public void OnStartPlayerTurn(Player player)
    {
        if(player == this)
        {
            hasMoved = false;
            StartCoroutine(TakeTurn());
        }
    }

    protected abstract IEnumerator TakeTurn();
}
