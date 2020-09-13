using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    [SerializeField]
    private AIBase aI;
    private bool awaitingTurn;
    [SerializeField]
    private GameObject superSecretBox;

    public void SetAIBase(AIBase aIBase, BattlecardTileEvent _event)
    {
        aI = aIBase;
        aI.SetPlayer(this);
        aI.SetPlayCardEvent(_event);
    }

    public void SetAIBoard(Board board)
    {
        aI.SetBoard(board);
    }

    public override void SetupHand()
    {
        for(int i = 0; i < hand.Count; i++)
        {
            hand[i].transform.parent = superSecretBox.transform;
            hand[i].transform.position = superSecretBox.transform.position;
            hand[i].SetOriginalOwner(this);
        }
    }

    protected override IEnumerator TakeTurn()
    {
        yield return null;
        StartCoroutine(aI.TakeTurn());
    }

    public override void OnPlayCard(BattlecardTilePlayerEventData data)
    {
        if(data.player == this)
        {
            hand.Remove(data.card);
            playedCards.Add(data.card);

            hasPlayedCard = true;
        }
    }
}
