using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardUtility
{
    // TODO: Surely there's a better way of handling this
    public static Dictionary<BattleCard, CardDirection> GetCardsToAttack(BattleCard card, Player attackingPlayer)
    {
        Dictionary<BattleCard, CardDirection> result = new Dictionary<BattleCard, CardDirection>();

        if (card.card.topLeft && card.tile.neighbors.topLeft != null && card.tile.neighbors.topLeft.card != null && card.tile.neighbors.topLeft.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.topLeft.card, CardDirection.topLeft);
        }
        if (card.card.top && card.tile.neighbors.top != null && card.tile.neighbors.top.card != null && card.tile.neighbors.top.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.top.card, CardDirection.top);
        }
        if (card.card.topRight && card.tile.neighbors.topRight != null && card.tile.neighbors.topRight.card != null && card.tile.neighbors.topRight.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.topRight.card, CardDirection.topRight);
        }
        if (card.card.right && card.tile.neighbors.right != null && card.tile.neighbors.right.card != null && card.tile.neighbors.right.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.right.card, CardDirection.right);
        }
        if (card.card.bottomRight && card.tile.neighbors.bottomRight != null && card.tile.neighbors.bottomRight.card != null && card.tile.neighbors.bottomRight.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.bottomRight.card, CardDirection.bottomRight);
        }
        if (card.card.bottom && card.tile.neighbors.bottom != null && card.tile.neighbors.bottom.card != null && card.tile.neighbors.bottom.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.bottom.card, CardDirection.bottom);
        }
        if (card.card.bottomLeft && card.tile.neighbors.bottomLeft != null && card.tile.neighbors.bottomLeft.card != null && card.tile.neighbors.bottomLeft.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.bottomLeft.card, CardDirection.bottomLeft);
        }
        if (card.card.left && card.tile.neighbors.left != null && card.tile.neighbors.left.card != null && card.tile.neighbors.left.card.currentOwner != attackingPlayer)
        {
            result.Add(card.tile.neighbors.left.card, CardDirection.left);
        }

        return result;
    }

    public static bool HasOpposingArrow(BattleCard card, CardDirection attackDirection)
    {
        switch(attackDirection)
        {
            case CardDirection.topLeft:
                return card.card.bottomRight;
            case CardDirection.top:
                return card.card.bottom;
            case CardDirection.topRight:
                return card.card.bottomLeft;
            case CardDirection.right:
                return card.card.left;
            case CardDirection.bottomRight:
                return card.card.topLeft;
            case CardDirection.bottom:
                return card.card.top;
            case CardDirection.bottomLeft:
                return card.card.topRight;
            case CardDirection.left:
                return card.card.right;
            default:
                return false;
        }
    }
}
