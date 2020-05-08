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

    public void OnPlayCard(CardTileEventData data)
    {
        hand.Remove(data.card);
        playedCards.Add(data.card);
    }

    public void OnStartPlayerTurn(Player player)
    {
        StartCoroutine(TakeTurn());
    }

    protected void EndTurn()
    {
        endTurnEvent.Raise(this);
    }

    protected abstract IEnumerator TakeTurn();
}
