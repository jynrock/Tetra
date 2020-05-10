using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardUtility
{
    // TODO: Surely there's a better way of handling this
    public static Dictionary<Card, CardDirection> GetCardsToAttack(Card card, Player attackingPlayer)
    {
        Dictionary<Card, CardDirection> result = new Dictionary<Card, CardDirection>();

        if (card.arrows.topLeft.Value && card.tile.neighbors.topLeft != null && card.tile.neighbors.topLeft.card != null && card.tile.neighbors.topLeft.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.topLeft.card, CardDirection.topLeft);
        }
        if (card.arrows.top.Value && card.tile.neighbors.top != null && card.tile.neighbors.top.card != null && card.tile.neighbors.top.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.top.card, CardDirection.top);
        }
        if (card.arrows.topRight.Value && card.tile.neighbors.topRight != null && card.tile.neighbors.topRight.card != null && card.tile.neighbors.topRight.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.topRight.card, CardDirection.topRight);
        }
        if (card.arrows.right.Value && card.tile.neighbors.right != null && card.tile.neighbors.right.card != null && card.tile.neighbors.right.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.right.card, CardDirection.right);
        }
        if (card.arrows.bottomRight.Value && card.tile.neighbors.bottomRight != null && card.tile.neighbors.bottomRight.card != null && card.tile.neighbors.bottomRight.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.bottomRight.card, CardDirection.bottomRight);
        }
        if (card.arrows.bottom.Value && card.tile.neighbors.bottom != null && card.tile.neighbors.bottom.card != null && card.tile.neighbors.bottom.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.bottom.card, CardDirection.bottom);
        }
        if (card.arrows.bottomLeft.Value && card.tile.neighbors.bottomLeft != null && card.tile.neighbors.bottomLeft.card != null && card.tile.neighbors.bottomLeft.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.bottomLeft.card, CardDirection.bottomLeft);
        }
        if (card.arrows.left.Value && card.tile.neighbors.left != null && card.tile.neighbors.left.card != null && card.tile.neighbors.left.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.left.card, CardDirection.left);
        }

        return result;
    }

    public static bool HasOpposingArrow(Card card, CardDirection attackDirection)
    {
        switch(attackDirection)
        {
            case CardDirection.topLeft:
                return card.arrows.bottomRight.Value;
            case CardDirection.top:
                return card.arrows.bottom.Value;
            case CardDirection.topRight:
                return card.arrows.bottomLeft.Value;
            case CardDirection.right:
                return card.arrows.left.Value;
            case CardDirection.bottomRight:
                return card.arrows.topLeft.Value;
            case CardDirection.bottom:
                return card.arrows.top.Value;
            case CardDirection.bottomLeft:
                return card.arrows.topRight.Value;
            case CardDirection.left:
                return card.arrows.right.Value;
            default:
                return false;
        }
    }
}
