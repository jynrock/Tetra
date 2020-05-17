using UnityEngine;
using UnityEngine.Events;

public class BattlecardAbilityEventListener : BaseListener<BattlecardAbilityEventData>
{

    [SerializeField] protected BattlecardAbilityEventCallBack callback;

    public override void OnRaise(BattlecardAbilityEventData data)
    {
        this.callback.Invoke(data);
    }
}
