using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    [SerializeField]
    private AIBase aI;

    void Start()
    {
        aI.SetPlayer(this);
    }

    protected override IEnumerator TakeTurn()
    {
        while(true)
        {
            yield return null;

            if(aI.TakeTurn())
            {
                break;
            }
            else
            {
                yield return null;
            }
        }

        EndTurn();
    }
}
