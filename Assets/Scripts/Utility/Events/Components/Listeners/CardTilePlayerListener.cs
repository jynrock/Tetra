using UnityEngine;
using UnityEngine.Events;

public class CardTilePlayerListener : BaseListener<CardTilePlayerEventData>
{

    [SerializeField] protected CardTilePlayerCallback callback;

    public override void OnRaise(CardTilePlayerEventData data)
    {
        this.callback.Invoke(data);
    }
}
