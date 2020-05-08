using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Tile> tiles;

    [SerializeField]
    BoardEvent calloutBoard;

    // Start is called before the first frame update
    void Start()
    {
        calloutBoard.Raise(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tile GetTile(int i)
    {
        if (i < tiles.Count)
        {
            return tiles[i];
        }
        else
        {
            return null;
        }
    }
}
