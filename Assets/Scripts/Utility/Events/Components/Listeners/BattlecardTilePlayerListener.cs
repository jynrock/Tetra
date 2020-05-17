using UnityEngine;
using UnityEngine.Events;

public class BattlecardTilePlayerListener : BaseListener<BattlecardTilePlayerEventData>
{

    [SerializeField] protected BattlecardTilePlayerCallback callback;

    public override void OnRaise(BattlecardTilePlayerEventData data)
    {
        this.callback.Invoke(data);
    }
}
