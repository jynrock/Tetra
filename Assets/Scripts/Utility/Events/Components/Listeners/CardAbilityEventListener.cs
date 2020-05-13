using UnityEngine;
using UnityEngine.Events;

public class CardAbilityEventListener : BaseListener<CardAbilityEventData>
{

    [SerializeField] protected CardAbilityEventCallBack callback;

    public override void OnRaise(CardAbilityEventData data)
    {
        this.callback.Invoke(data);
    }
}
