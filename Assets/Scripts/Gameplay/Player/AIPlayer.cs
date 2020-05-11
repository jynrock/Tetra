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

    void Start()
    {
        aI.SetPlayer(this);
    }

    public override void SetupHand()
    {
        for(int i = 0; i < hand.Count; i++)
        {
            Card c = hand[i];
            hand[i] = Instantiate(c);
            hand[i].transform.position = superSecretBox.transform.position;
            hand[i].SetOriginalOwner(this);
        }
    }

    protected override IEnumerator TakeTurn()
    {
        yield return null;
        aI.TakeTurn();
        while(!hasPlayedCard && !hasUsedAbility)
        {
            yield return new WaitForSeconds(2.0f);
        }
    }

    public override void OnPlayCard(CardTilePlayerEventData data)
    {
        if(data.player == this)
        {
            hand.Remove(data.card);
            playedCards.Add(data.card);

            hasPlayedCard = true;
        }
    }
}
