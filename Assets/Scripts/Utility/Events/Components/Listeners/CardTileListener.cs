using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed FloatGameEvent is raised
public class CardTileListener : BaseListener<CardTileEventData>
{

    [SerializeField] protected CardTileCallback callback;

    public override void OnRaise(CardTileEventData data)
    {
        this.callback.Invoke(data);
    }
}
