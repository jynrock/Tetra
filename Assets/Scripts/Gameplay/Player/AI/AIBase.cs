using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBase : MonoBehaviour
{
    [SerializeField]
    protected Board board;
    [SerializeField]
    protected Player player;
    [SerializeField]
    protected BattlecardTileEvent tryPlayCardEvent;

    public void SetPlayer(Player p)
    {
        player = p;
    }

    public void SetBoard(Board b)
    {
        board = b;
    }

    public void SetPlayCardEvent(BattlecardTileEvent _event)
    {
        tryPlayCardEvent = _event;
    }

    protected Tile GetRandomTile()
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

    protected BattleCard GetRandomCardFromHand()
    {
        BattleCard result = null;

        if(player.hand.Count > 0)
        {
            int i = Random.Range(0, player.hand.Count);
            result = player.hand[i];
        }

        return result;
    }

    protected BattleCard GetRandomPlayerOwnedCardOnBoard()
    {
        List<BattleCard> test = board.cardsInPlay.Where(c => c.currentOwner = player).ToList();
        if(test.Count > 0)
        {
            int random = Random.Range(0, test.Count);
            return test[random];
        }
        return null;
    }

    protected void UseRandomAbilityOnRandomFriendlyCards()
    {
        BattleCard abilityC = GetRandomPlayerOwnedCardOnBoard();
        abilityC.BeginUseAbility();
        
        BattleCard abilityTarget = GetRandomPlayerOwnedCardOnBoard();
        abilityC.OnTargetSelected(abilityTarget);

        if(abilityC.card.cardAbility.type == AbilityType.TWO_TARGET)
        {
            BattleCard abilityTargetTwo = null;
            do
            {
                abilityTargetTwo = GetRandomPlayerOwnedCardOnBoard();
            } while (abilityTargetTwo != null && abilityTargetTwo != abilityTarget);
            abilityC.OnTargetSelected(abilityTargetTwo);
        }
    }

    public abstract void TakeTurn();
}
