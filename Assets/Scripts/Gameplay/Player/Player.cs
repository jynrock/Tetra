using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public List<Card> hand;

    public List<Card> playedCards;

    [SerializeField]
    protected PlayerEvent endTurnEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupHand()
    {
        foreach(Card c in hand)
        {
            c.SetOriginalOwner(this);
        }
    }

    public abstract void OnPlayCard(CardTilePlayerEventData data);

    public void OnStartPlayerTurn(Player player)
    {
        if(player == this)
        {
            StartCoroutine(TakeTurn());
        }
    }

    protected void EndTurn()
    {
        endTurnEvent.Raise(this);
    }

    protected abstract IEnumerator TakeTurn();
}
