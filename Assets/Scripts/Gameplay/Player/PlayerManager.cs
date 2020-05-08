using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<Player> players;
    public Player currentPlayerTurn;

    [SerializeField]
    private PlayerEvent startPlayerTurnEvent;

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
        startPlayerTurnEvent.Raise(currentPlayerTurn);
    }

    public void OnStartGame()
    {
        currentPlayerTurn = players[0];
        startPlayerTurnEvent.Raise(currentPlayerTurn);
    }
}
