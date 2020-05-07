using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed event is raised
public class Listener : BaseListener<object>
{

    [SerializeField] private UnityEvent callback;

    public override void OnRaise(object data = null)
    {
        this.callback.Invoke();
    }
}
