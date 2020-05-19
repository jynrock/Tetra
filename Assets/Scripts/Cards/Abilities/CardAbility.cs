using System;
using System.Collections;
using UnityEngine;

public abstract class CardAbility : ScriptableObject
{
    public string abilityName = "New Ability";
    public string abilityDescription = "New Ability Description";
    public AbilityType type;

    [SerializeField]
    protected BoolGameEvent targetListeningEvent;
    [SerializeField]
    protected BattlecardAbilityEvent tryUseAbilityEvent;

    protected BattleCard sourceCard;

    protected BattleCard firstTarget;
    protected BattleCard secondTarget;

    public void Activate(BattleCard _sourceCard)
    {
        sourceCard = _sourceCard;
        targetListeningEvent.Raise(true);
    }

    public void Deactivate()
    {
        targetListeningEvent.Raise(false);
        ResetAbility();
    }

    public abstract void OnTargetSelected(BattleCard card);

    private void ResetAbility()
    {
        sourceCard = null;
        firstTarget = null;
        secondTarget = null;
    }

    public abstract IEnumerator HandleAbility(BattlecardAbilityEventData data);
}
