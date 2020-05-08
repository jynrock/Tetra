using UnityEngine;
using UnityEngine.Events;

public class BoardListener : BaseListener<Board>
{

    [SerializeField] protected BoardCallback callback;

    public override void OnRaise(Board data)
    {
        this.callback.Invoke(data);
    }
}
