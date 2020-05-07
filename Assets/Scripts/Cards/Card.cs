using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public StringProperty Name;
    public StringProperty Description;
    public IntProperty Health;
    public int Type;
    public IntProperty Attack;
    public IntProperty Defense;
    public MeshRenderer cardFront;
    public MeshRenderer cardBack;
    public CardArrows arrows;
    public Tile tile;

    private Vector3 offset;
    private Vector3 screenPoint;
    private bool waitingForTryPlayResult;
    [SerializeField]
    CardTileEvent tryPlayCardEvent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void ResetPosition()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
