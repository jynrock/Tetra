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
    CardTilePlayerEvent playCardSucceededEvent;
    [SerializeField]
    CardTilePlayerEvent playCardFailedEvent;
    [SerializeField]
    PlayerIntEvent onStartGameOverEvent;

    void Start()
    {
        foreach(Player p in players)
        {
            p.SetupHand();
        }
        OnStartGame();
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

    public void OnTryPlayCard(CardTileEventData data)
    {
        CardTilePlayerEventData newData = new CardTilePlayerEventData(data.card, data.tile, currentPlayerTurn);
        if (CanPlayCardOnTile(data))
        {
            playCardSucceededEvent.Raise(newData);
        }
        else
        {
            playCardFailedEvent.Raise(newData);
        }
    }

    public bool CanPlayCardOnTile(CardTileEventData data)
    {
        return data.tile.card == null
                && data.tile.blocker == null
                && data.card.tile == null;
    }
}
