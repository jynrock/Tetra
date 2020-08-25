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

    [SerializeField]
    AnimationCurve attackCurve;

    public List<BattleCard> cardsInPlay;

    [SerializeField]
    private PlayerEvent endAwaitAnimationsEvent;

    public void OnGameLoaded(bool loaded)
    {
        if(loaded)
        {
            SetUpTiles();
            cardsInPlay = new List<BattleCard>();
            calloutBoard.Raise(this);
        }
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

        int numTilesToBlock = Random.Range(0, 7);
        int numTilesBlocked = 0;
        while (numTilesBlocked != numTilesToBlock)
        {
            //get random tile
            Tile t = null;
            do
            {
                t = tilesList[Random.Range(0, tilesList.Count - 1)];
            }
            while (t.blocker != null);
            t.AddBlocker();
            numTilesBlocked++;
        }

    }

    public void HandleCardCombat(BattlecardListDirectionEventData data)
    {
        StartCoroutine(HandleCardCombatAsync(data));
    }

    public IEnumerator HandleCardCombatAsync(BattlecardListDirectionEventData data)
    {
        BattleCard attackingCard = data.card;
        foreach(KeyValuePair<BattleCard,CardDirection> pair in data.cardList)
        {
            yield return null;
            BattleCard defendingCard = pair.Key;
            CardDirection attackDirection = pair.Value;

            int attack = Mathf.RoundToInt(attackingCard.card.attack / data.cardList.Count);

            if(CardUtility.HasOpposingArrow(defendingCard, attackDirection))
            {
                attack = Mathf.RoundToInt((attack * 0.75f) + 0.5f);
            }
            
            if (attack < 1) {
                attack = 1;
            }

            Vector3 origin = attackingCard.transform.position;

            float journey = 0f;
            float duration = 0.15f;
            while(journey <= duration)
            {
                journey = journey + Time.deltaTime;
                float percent = Mathf.Clamp01(journey / duration);
                float curvePercent = attackCurve.Evaluate(percent);
                attackingCard.transform.position = Vector3.LerpUnclamped(attackingCard.transform.position, defendingCard.transform.position, curvePercent);
                yield return null;
            }
            journey = 0f;
            duration = 0.15f;
            while(journey <= duration)
            {
                journey = journey + Time.deltaTime;
                float percent = Mathf.Clamp01(journey / duration);
                attackingCard.transform.position = Vector3.Lerp(defendingCard.transform.position, origin, percent);
                yield return null;
            }

            defendingCard.TakeDamage(attack, attackingCard.currentOwner);
        }
        endAwaitAnimationsEvent.Raise(data.card.currentOwner);
    }

    public void OnPlayCardSucceeded(BattlecardTilePlayerEventData data)
    {
        cardsInPlay.Add(data.card);
    }
}
