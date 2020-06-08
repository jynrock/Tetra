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

    public abstract void TakeTurn();
}
