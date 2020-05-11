using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PlayerUtility
{
    public static Player GetWinningPlayer(List<Player> players, List<Card> cardsInPlay)
    {
        Dictionary<Player, int> results = new Dictionary<Player, int>();

        foreach(Player p in players)
        {
            results.Add(p, cardsInPlay.Where(c => c.currentOwner == p).Count());
        }

        results.OrderByDescending(kvp => kvp.Value);

        return results.First().Key;
    }

    public static Dictionary<Player, int> GetWinningPlayer(List<Player> players)
    {
        Dictionary<Player, int> results = new Dictionary<Player, int>();

        foreach(Player p in players)
        {
            foreach(Card c in p.playedCards)
            {
                if(results.Keys.Contains(c.currentOwner))
                {
                    results[c.currentOwner] += 1;
                }
                else
                {
                    results.Add(c.currentOwner, 1);
                }
            }
        }

        return results;
    }
}
