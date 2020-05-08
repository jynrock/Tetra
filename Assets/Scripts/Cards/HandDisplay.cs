using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplay : MonoBehaviour
{
    public Player owner;

    public List<GameObject> fakeCards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayCard(CardTilePlayerEventData data)
    {
        if( data.player == owner)
        {
            GameObject fakeCard = fakeCards[fakeCards.Count - 1];
            fakeCards.Remove(fakeCard);
            Destroy(fakeCard);
        }
    }
}
