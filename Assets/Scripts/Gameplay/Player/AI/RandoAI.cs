using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandoAI : AIBase
{
    public override void TakeTurn()
    {
        int oneInTen = Random.Range(0, 10);
        if(player.hand.Count >= 5 || oneInTen != 9)
        {
            Tile t = GetRandomTile();
            BattleCard c = GetRandomCardFromHand();
            if(t != null && c != null)
            {
                tryPlayCardEvent.Raise(new BattlecardTileEventData(c, t));
            }
        }
        EndTurn();
    }

    private void EndTurn()
    {
        player.StartCombatPhase();
    }
}
