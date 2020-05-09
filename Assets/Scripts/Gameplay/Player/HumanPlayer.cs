using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    public override void OnPlayCard(CardTilePlayerEventData data)
    {
        if(data.player == this)
        {
            hand.Remove(data.card);
            playedCards.Add(data.card);
        }
    }

    public void OnEndTurnButtonPressed()
    {
        StartCoroutine(HandleCombatPhase());
    }

    protected override IEnumerator TakeTurn()
    {
        yield return null;
    }
}
