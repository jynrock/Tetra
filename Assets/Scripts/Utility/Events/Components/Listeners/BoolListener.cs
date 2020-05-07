using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed BoolGameEvent is raised
public class BoolListener : BaseListener<bool>
{

    [SerializeField] protected BoolCallback callback;

    public override void OnRaise(bool data)
    {
        this.callback.Invoke(data);
    }
}
