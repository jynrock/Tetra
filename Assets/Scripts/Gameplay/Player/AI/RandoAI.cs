using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandoAI : AIBase
{
    public override IEnumerator TakeTurn()
    {
        int oneInTen = Random.Range(0, 10);
        if(player.hand.Count >= 5 || oneInTen != 9)
        {
            Tile t = GetRandomTile();
            BattleCard playC = GetRandomCardFromHand();
            if(t != null && playC != null)
            {
                tryPlayCardEvent.Raise(new BattlecardTileEventData(playC, t));
                yield return new WaitForSeconds(0.25f);
            }
        }
        int oneInEight = Random.Range(0, 8);
        if(player.hand.Count < 4 && oneInEight == 7)
        {
            UseRandomAbilityOnRandomFriendlyCards();
        }
        EndTurn();
    }

    private void EndTurn()
    {
        player.StartCombatPhase();
    }
}
