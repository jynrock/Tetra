using UnityEngine;
using UnityEngine.Events;

public class CardListDirectionListener : BaseListener<CardListDirectionEventData>
{

    [SerializeField] protected CardListDirectionCallBack callback;

    public override void OnRaise(CardListDirectionEventData data)
    {
        this.callback.Invoke(data);
    }
}
