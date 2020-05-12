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
    public Material cardArt;
    public Tile tile;
    public Player currentOwner;
    public Player originalOwner;

    public bool topLeft;
    public bool top;
    public bool topRight;
    public bool left;
    public bool right;
    public bool bottomLeft;
    public bool bottom;
    public bool bottomRight;

    private Vector3 offset;
    private Vector3 screenPoint;
    private Vector3 originPoint;
    private bool waitingForTryPlayResult;
    private bool controlsDisabled;
    [SerializeField]
    private CardDisplay statDisplay;
    [SerializeField]
    private CardTileEvent tryPlayCardEvent;
    [SerializeField]
    private CardEvent showPreviewEvent;
    [SerializeField]
    private CardEvent hidePreviewEvent;

    public void SetOriginalOwner(Player player)
    {
        originalOwner = player;
        currentOwner = player;
        statDisplay.UpdateStats();
    }

    public void SetCurrentOwner(Player player)
    {
        currentOwner = player;
        statDisplay.UpdateStats();
    }

    // MOUSE CONTROLS
    void OnMouseDown()
    {
        if(!controlsDisabled && tile == null)
        {
            originPoint = transform.position;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset =  transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
        }
        showPreviewEvent.Raise(this);
    }

    void OnMouseDrag()
    {
        if (!controlsDisabled && !currentOwner.hasPlayedCard && tile == null)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            if ((curPosition - originPoint).sqrMagnitude >= 0.1f)
            {
                hidePreviewEvent.Raise(this);
            }
        }  
    }

    void OnMouseUp()
    {
        if (!controlsDisabled && tile == null)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, 250);
            if(hit.collider != null)
            {
                Tile targetTile = hit.collider.gameObject.GetComponent<Tile>();
                if (targetTile != null && !currentOwner.hasPlayedCard)
                {
                    hidePreviewEvent.Raise(this);
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
    public void OnTryPlayCardSucceeded(CardTilePlayerEventData data)
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

    public void OnTryPlayCardFailed(CardTilePlayerEventData data)
    {
        if(data.card == this)
        {
            waitingForTryPlayResult = false;
            ResetPosition();
        }
    }

    public void OnPlayerTurnEnded(Player _player)
    {
        if (currentOwner == _player)
        {
            controlsDisabled = true;
        }
    }

    public void OnPlayerTurnStarted(Player _player)
    {
        if (currentOwner == _player)
        {
            controlsDisabled = false;
        }
    }

    //TODO: We may want to make this event driven
    public void TakeDamage(int dmg, Player _currentOwner)
    {
        if (dmg < 1)
        {
            dmg = 1;
        }
        health -= dmg;
        if (health <= 0)
        {
            SetCurrentOwner(_currentOwner);
            health = 1;
        }
        statDisplay.UpdateStats();
    }

    // PRIVATE FUNCTIONS
    private void ResetPosition()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
