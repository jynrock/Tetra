using UnityEngine;
using UnityEngine.Events;

public class CardTileListener : BaseListener<CardTileEventData>
{

    [SerializeField] protected CardTileCallback callback;

    public override void OnRaise(CardTileEventData data)
    {
        this.callback.Invoke(data);
    }
}
