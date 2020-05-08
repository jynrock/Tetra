using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandoAI : AIBase
{
    public override bool TakeTurn()
    {
        Debug.Log(board);
        Debug.Log(player);
        return true;
    }
}
