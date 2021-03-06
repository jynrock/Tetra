using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCard : MonoBehaviour
{
    public CardInstance card;
    public Tile tile;
    public Player currentOwner;
    public Player originalOwner;
    public bool cardAbilityUsed;


    private Vector3 offset;
    private Vector3 screenPoint;
    private Vector3 originPoint;
    private bool waitingForTryPlayResult;
    private bool controlsDisabled;
    private bool targetListening;
    private bool abilityActive;
    [SerializeField]
    private CardDisplay statDisplay;
    [SerializeField]
    private BattlecardTileEvent tryPlayCardEvent;
    [SerializeField]
    private BattlecardEvent showPreviewEvent;
    [SerializeField]
    private BattlecardEvent hidePreviewEvent;
    [SerializeField]
    private BattlecardEvent selectCardEvent;

    private bool dragging;

    void Start()
    {
    }

    public void SetCardInstance(CardInstance instance)
    {
        card = instance;
    }

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
        }
        else if(!controlsDisabled) 
        {
            if(targetListening)
            {
                statDisplay.ToggleOutline(true);
                selectCardEvent.Raise(this);
            }
        }
        showPreviewEvent.Raise(this);
    }

    void OnMouseDrag()
    {
        if (!controlsDisabled && !currentOwner.hasPlayedCard && tile == null)
        {
            dragging = true;
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Ray ray = Camera.main.ScreenPointToRay(curScreenPoint);
            RaycastHit[] hits = Physics.RaycastAll(ray, 5.0f);
            foreach(RaycastHit hit in hits)
            {
                if(hit.transform.tag == "CardDragPlane") {
                    Vector3 hitPos = hit.point;
                    transform.position = new Vector3(hitPos.x, hitPos.y + 0.05f, hitPos.z);
                }
            }
            if ((transform.position - originPoint).sqrMagnitude >= 0.1f)
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
                    tryPlayCardEvent.Raise(new BattlecardTileEventData(this, targetTile));
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
        if(tile == null && !dragging && !controlsDisabled && PlayerManager.Instance.currentPlayerTurn == currentOwner)
        {
            Vector3 newPos = transform.position;
            newPos.y += 0.05f;
            transform.position = newPos;
        }
    }

    void OnMouseExit()
    {
        if(!dragging){
            ResetPosition();
        }
    }

    // PLAYING CARD FUNCTIONS
    public void OnTryPlayCardSucceeded(BattlecardTilePlayerEventData data)
    {
        if(data.card == this)
        {
            if (tile != null)
            {
                tile.card = null;
            }
            waitingForTryPlayResult = false;
            tile = data.tile;
            dragging = false;
        }
    }

    public void OnTryPlayCardFailed(BattlecardTilePlayerEventData data)
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

    public void OnDisableControls(bool disable)
    {
        controlsDisabled = disable;
    }

    //TODO: We may want to make this event driven
    public void TakeDamage(int dmg, Player _currentOwner)
    {
        if (dmg < 1)
        {
            dmg = 1;
        }
        card.health -= dmg;
        if (card.health <= 0)
        {
            SetCurrentOwner(_currentOwner);
            card.health = 1;
        }
        statDisplay.UpdateStats();
    }

    public void Heal(int toHeal)
    {
        if (card.health + toHeal >= card.maxHealth)
        {
            card.health = card.maxHealth;
        }
        else
        {
            card.health += toHeal;
        }
        statDisplay.UpdateStats();
    }

    public void OnTargetListeningEvent(bool shouldListen)
    {
        targetListening = shouldListen;
    }

    public void BeginUseAbility()
    {
        abilityActive = true;
        card.cardAbility.Activate(this);
    }

    public void OnTryUseAbilitySucceeded(BattlecardAbilityEventData data)
    {
        if(data.sourceCard == this)
        {
            cardAbilityUsed = true;
            abilityActive = false;
            StartCoroutine(card.cardAbility.HandleAbility(data));
            card.cardAbility.Deactivate();
        }
        statDisplay.ToggleOutline(false);
    }

    public void OnTryUseAbilityFailed(BattlecardAbilityEventData data)
    {
        if(data.sourceCard == this)
        {
            abilityActive = false;
            card.cardAbility.Deactivate();
        }
        statDisplay.ToggleOutline(false);
    }
    public void OnTargetSelected(BattleCard data)
    {
        if(abilityActive == true)
        {
            card.cardAbility.OnTargetSelected(data);
        }
    }

    public void BoostAttack(int amt)
    {
        card.attack += amt;
        statDisplay.UpdateStats();
    }

    public void BoostHealth(int amt)
    {
        card.maxHealth += amt;
        card.health += amt;
        statDisplay.UpdateStats();
    }

    // PRIVATE FUNCTIONS
    private void ResetPosition()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        dragging = false;
    }
}
