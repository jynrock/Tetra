using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed FloatGameEvent is raised
public class FloatListener : BaseListener<float>
{

    [SerializeField] protected FloatCallback callback;

    public override void OnRaise(float data)
    {
        this.callback.Invoke(data);
    }
}
