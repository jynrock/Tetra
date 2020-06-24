using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed StringEvent is raised
public class CardListener : BaseListener<Card>
{

    [SerializeField] private CardEventCallBack callback;

    public override void OnRaise(Card data)
    {
        this.callback.Invoke(data);
    }
}
