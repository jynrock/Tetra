using UnityEngine;
using UnityEngine.Events;

public class PlayerListener : BaseListener<Player>
{

    [SerializeField] protected PlayerCallback callback;

    public override void OnRaise(Player data)
    {
        this.callback.Invoke(data);
    }
}
