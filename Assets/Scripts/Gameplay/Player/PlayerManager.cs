using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<Player> players;
    public Player currentPlayerTurn;

    [SerializeField]
    private PlayerEvent startPlayerTurnEvent;

    [SerializeField]
    BattlecardTilePlayerEvent playCardSucceededEvent;
    [SerializeField]
    BattlecardTilePlayerEvent playCardFailedEvent;
    [SerializeField]
    PlayerIntEvent onStartGameOverEvent;
    [SerializeField]
    BattlecardAbilityEvent onTryUseAbilitySucceededEvent;
    [SerializeField]
    BattlecardAbilityEvent onTryUseAbilityFailedEvent;

    #region Singleton
    private static PlayerManager _instance;
    public static PlayerManager Instance { get {return _instance;} }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    #endregion


    public void OnGameLoaded(bool loaded)
    {
        if(loaded)
        {
            foreach(Player p in players)
            {
                p.SetupHand();
            }
            OnStartGame();
        }
    }

    public void OnEndPlayerTurn(Player player)
    {
        currentPlayerTurn = players[(players.IndexOf(player) + 1) % players.Count];

        if (players.Where(p => !(p.hand.Count == 0)).ToList().Any())
        {
            startPlayerTurnEvent.Raise(currentPlayerTurn);
        }
        else
        {
            Dictionary<Player, int> winners = PlayerUtility.GetWinningPlayer(players);
            onStartGameOverEvent.Raise(winners);
        }

    }

    public void OnStartGame()
    {
        currentPlayerTurn = players[0];
        startPlayerTurnEvent.Raise(currentPlayerTurn);
    }

    public void OnTryPlayCard(BattlecardTileEventData data)
    {
        BattlecardTilePlayerEventData newData = new BattlecardTilePlayerEventData(data.card, data.tile, currentPlayerTurn);
        if (CanPlayCardOnTile(data))
        {
            playCardSucceededEvent.Raise(newData);
        }
        else
        {
            playCardFailedEvent.Raise(newData);
        }
    }

    public bool CanPlayCardOnTile(BattlecardTileEventData data)
    {
        return data.tile.card == null
                && data.tile.blocker == null
                && data.card.tile == null
                && PlayerManager.Instance.currentPlayerTurn == data.card.currentOwner;
    }

    public void OnTryUseCardAbility(BattlecardAbilityEventData data)
    {
        if (data.sourceCard != null 
            && !data.sourceCard.cardAbilityUsed
            && data.sourceCard.tile != null
            && data.sourceCard.currentOwner == currentPlayerTurn
            && !data.sourceCard.currentOwner.hasUsedAbility
            && data.target != null)
        {
            if (data.type == AbilityType.ONE_TARGET)
            {
                onTryUseAbilitySucceededEvent.Raise(data);
                data.sourceCard.currentOwner.hasUsedAbility = true;
                return;
            }
            if (data.type == AbilityType.TWO_TARGET)
            {
                if (data.secondTarget != null
                    && data.secondTarget.tile != null)
                {
                    onTryUseAbilitySucceededEvent.Raise(data);
                    return;
                }
            }
        }
        onTryUseAbilityFailedEvent.Raise(data);
    }
}
