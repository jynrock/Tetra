using UnityEngine;
using UnityEngine.Events;

public class BattlecardListDirectionListener : BaseListener<BattlecardListDirectionEventData>
{

    [SerializeField] protected BattlecardListDirectionCallBack callback;

    public override void OnRaise(BattlecardListDirectionEventData data)
    {
        this.callback.Invoke(data);
    }
}
