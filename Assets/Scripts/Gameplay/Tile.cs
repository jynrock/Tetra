using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private CardEvent playCardEvent;

    [SerializeField]
    private GameObject cardHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCard(Card cardToPlay)
    {
        playCardEvent.Raise(cardToPlay);
        cardToPlay.transform.SetParent(cardHolder.transform);
        cardToPlay.transform.position = cardHolder.transform.position;
    }
}
