using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Tile> tilesList;
    public Tile[,] tiles;
    public int rows;
    public int columns;

    [SerializeField]
    BoardEvent calloutBoard;

    // Start is called before the first frame update
    void Start()
    {
        SetUpTiles();
        calloutBoard.Raise(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tile GetTile(int i)
    {
        if (i < tilesList.Count)
        {
            return tilesList[i];
        }
        else
        {
            return null;
        }
    }

    public Tile GetTile(int x, int y)
    {

        return tiles[x,y];
    }

    public TileNeighbors GetTileNeighbors(Tile tile)
    {
        TileNeighbors neighbors = new TileNeighbors();
        
        bool hasBottom = tile.row + 1 < rows;
        bool hasTop = tile.row - 1 >= 0;
        bool hasRight = tile.column + 1 < columns;
        bool hasLeft = tile.column - 1 >= 0;

        if(hasRight)
        {
            neighbors.right = tiles[tile.row, tile.column + 1];
        }
        if(hasLeft)
        {
            neighbors.left = tiles[tile.row, tile.column - 1];
        }
        if(hasTop)
        {
            neighbors.top = tiles[tile.row - 1, tile.column];
            if(hasRight)
            {
                neighbors.topRight = tiles[tile.row - 1, tile.column + 1];
            }
            if(hasLeft)
            {
                neighbors.topLeft = tiles[tile.row - 1, tile.column - 1];
            }
        }
        if(hasBottom)
        {
            neighbors.bottom = tiles[tile.row + 1, tile.column];
            if(hasRight)
            {
                neighbors.bottomRight = tiles[tile.row + 1, tile.column + 1];
            }
            if(hasLeft)
            {
                neighbors.bottomLeft = tiles[tile.row + 1, tile.column - 1];
            }
        }

        return neighbors;
    }

    private void SetUpTiles()
    {
        tiles = new Tile[rows,columns];
        for(int i = 0; i < tilesList.Count; i++)
        {
            Tile t = tilesList[i];
            int row = i / rows;
            int column = i % columns;

            tiles[row, column] = t;
            t.row = row;
            t.column = column;
        }
    }

    public void HandleCardCombat(CardListDirectionEventData data)
    {
        foreach(KeyValuePair<Card,CardDirection> pair in data.cardList)
        {
            int attack = data.card.attack;
            int defense = pair.Key.defense;

            pair.Key.TakeDamage(attack - defense);
        }
    }
}
