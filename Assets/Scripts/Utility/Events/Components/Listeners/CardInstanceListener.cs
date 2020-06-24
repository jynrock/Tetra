using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed StringEvent is raised
public class CardInstanceListener : BaseListener<CardInstance>
{

    [SerializeField] private CardInstanceEventCallBack callback;

    public override void OnRaise(CardInstance data)
    {
        this.callback.Invoke(data);
    }
}
