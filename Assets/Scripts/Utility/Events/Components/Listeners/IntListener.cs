using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed IntGameEvent is raised
public class IntListener : BaseListener<int>
{

    [SerializeField] public IntCallback callback;

    public override void OnRaise(int data)
    {
        this.callback.Invoke(data);
    }
}
