using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public List<Card> hand;

    public List<Card> playedCards;

    [SerializeField]
    private PlayerEvent endTurnEvent;
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

    public void OnPlayCard(CardTileEventData data)
    {
        hand.Remove(data.card);
        playedCards.Add(data.card);

        endTurnEvent.Raise(this);
    }

    public void OnStartPlayerTurn(Player player)
    {
        if(player == this)
        {
            Debug.Log("Starting player turn...");
            StartCoroutine(TakeTurn());
        }
    }

    protected void EndTurn()
    {
        endTurnEvent.Raise(this);
    }

    protected abstract IEnumerator TakeTurn();
}
