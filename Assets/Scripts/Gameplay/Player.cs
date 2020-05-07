using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<Card> hand;

    public List<Card> playedCards;
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
}
