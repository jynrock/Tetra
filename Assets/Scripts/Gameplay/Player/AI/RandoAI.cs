using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandoAI : AIBase
{
    public override void TakeTurn()
    {
        Tile t = GetRandomTile();
        Card c = GetRandomCardFromHand();
        if(t != null && c != null)
        {
            tryPlayCardEvent.Raise(new CardTileEventData(c, t));
        }
        else
        {
            StartCoroutine(player.HandleCombatPhase());
        }
    }

    private Tile GetRandomTile()
    {
        Tile result = null;

        List<int> tilesTried = new List<int>();
        do
        {
            int i = 0;
            do
            {
                i = Random.Range(0, board.tilesList.Count);
            }
            while (tilesTried.Contains(i));

            tilesTried.Add(i);
            result = board.tilesList[i];
        }
        while (result.card != null || result.blocker != null);

        return result;
    }

    private Card GetRandomCardFromHand()
    {
        Card result = null;

        if(player.hand.Count > 0)
        {
            int i = Random.Range(0, player.hand.Count);
            result = player.hand[i];
        }

        return result;
    }
}
