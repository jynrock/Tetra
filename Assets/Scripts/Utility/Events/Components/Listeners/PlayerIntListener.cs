using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerIntListener : BaseListener<Dictionary<Player, int>>
{

    [SerializeField] protected PlayerIntCallback callback;

    public override void OnRaise(Dictionary<Player, int> data)
    {
        this.callback.Invoke(data);
    }
}
