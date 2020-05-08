using UnityEngine;
using UnityEngine.Events;

public class CardListener : BaseListener<Card>
{

    [SerializeField] protected CardCallback callback;

    public override void OnRaise(Card data)
    {
        this.callback.Invoke(data);
    }
}
