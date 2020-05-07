using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed StringEvent is raised
public class StringListener : BaseListener<string>
{

    [SerializeField] private StringCallback callback;

    public override void OnRaise(string data)
    {
        this.callback.Invoke(data);
    }
}
