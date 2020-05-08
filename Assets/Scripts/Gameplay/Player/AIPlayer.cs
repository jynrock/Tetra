using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    protected override IEnumerator TakeTurn()
    {
        while(true)
        {
            yield return null;

            yield return new WaitForSeconds(0.5f);

            break;
        }

        EndTurn();
    }
}
