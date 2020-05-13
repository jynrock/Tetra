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
    [SerializeField]
    private Blocker blockerPrefab;
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
            SetCard(data.card);
        }
    }

    public void OnCallOutBoard(Board board)
    {
        neighbors = board.GetTileNeighbors(this);
    }

    public void AddBlocker()
    {
        blocker = Instantiate(blockerPrefab);
        blocker.transform.SetParent(this.transform);
        blocker.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void SetCard(Card _card)
    {
        card = _card;
        card.transform.SetParent(cardHolder.transform);
        card.transform.localPosition = new Vector3(0, 0, 0);
    }
}
