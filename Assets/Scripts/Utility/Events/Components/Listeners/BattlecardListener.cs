using UnityEngine;
using UnityEngine.Events;

public class BattlecardListener : BaseListener<BattleCard>
{

    [SerializeField] protected BattleCardCallback callback;

    public override void OnRaise(BattleCard data)
    {
        this.callback.Invoke(data);
    }
}
