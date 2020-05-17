using UnityEngine;
using UnityEngine.Events;

public class BattlecardTileListener : BaseListener<BattlecardTileEventData>
{

    [SerializeField] protected BattlecardTileCallback callback;

    public override void OnRaise(BattlecardTileEventData data)
    {
        this.callback.Invoke(data);
    }
}
