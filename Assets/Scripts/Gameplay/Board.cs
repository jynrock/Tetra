using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Tile> tiles;

    [SerializeField] CardTileEvent playCardSucceededEvent;
    [SerializeField] CardTileEvent playCardFailedEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTryPlayCard(CardTileEventData data)
    {
        if (CanPlayCardOnTile(data))
        {
            playCardSucceededEvent.Raise(data);
        }
        else
        {
            playCardFailedEvent.Raise(data);
        }
    }

    public bool CanPlayCardOnTile(CardTileEventData data)
    {
        return data.tile.card == null && data.card.tile == null;
    }
}
