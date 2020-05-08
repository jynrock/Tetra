using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;
    public string cardDesc;
    public int health;
    public int type;
    public int attack;
    public int defense;
    public MeshRenderer cardArt;
    public MeshRenderer cardFront;
    public MeshRenderer cardBack;
    public CardArrows arrows;
    public Tile tile;
    public Player currentOwner;
    public Player originalOwner;

    private Vector3 offset;
    private Vector3 screenPoint;
    private bool waitingForTryPlayResult;
    [SerializeField]
    CardTileEvent tryPlayCardEvent;

    public void SetOriginalOwner(Player player)
    {
        originalOwner = player;
        currentOwner = player;
    }

    // MOUSE CONTROLS
    void OnMouseDown()
    {
        if(tile == null)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset =  transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (tile == null)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 250);
        if(hit.collider != null)
        {
            Tile targetTile = hit.collider.gameObject.GetComponent<Tile>();
            if (targetTile != null)
            {
                tryPlayCardEvent.Raise(new CardTileEventData(this, targetTile));
                waitingForTryPlayResult = true;
            }
            else
            {
                ResetPosition();
            }
        }
        else
        {
            ResetPosition();
        }
    }

    void OnMouseEnter()
    {
        if(tile == null)
        {
            Vector3 newPos = transform.position;
            newPos.z -= 0.1f;
            transform.position = newPos;
        }
    }

    void OnMouseExit()
    {
        ResetPosition();
    }

    // PLAYING CARD FUNCTIONS
    public void OnTryPlayCardSucceeded(CardTileEventData data)
    {
        if(data.card == this)
        {
            if (tile != null)
            {
                tile.card = null;
            }
            waitingForTryPlayResult = false;
            tile = data.tile;
        }
    }

    public void OnTryPlayCardFailed(CardTileEventData data)
    {
        if(data.card == this)
        {
            waitingForTryPlayResult = false;
            ResetPosition();
        }
    }

    // PRIVATE FUNCTIONS
    private void ResetPosition()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
