using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Card card;
    public Blocker blocker;
    public int row;
    public int column;
    public TileNeighbors neighbors;
    
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

    public void OnTryPlayCardSucceeded(CardTilePlayerEventData data)
    {
        if(data.tile == this)
        {
            card = data.card;
            card.transform.SetParent(cardHolder.transform);
            card.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void OnCallOutBoard(Board board)
    {
        neighbors = board.GetTileNeighbors(this);
    }
}
