using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public abstract class CardAbility : ScriptableObject
{
    [SerializeField]
    private LocalizedString localizedName;
    [SerializeField]
    private LocalizedString localizedDescription;
    public AbilityType type;

    [SerializeField]
    protected BoolGameEvent targetListeningEvent;
    [SerializeField]
    protected BattlecardAbilityEvent tryUseAbilityEvent;

    protected BattleCard sourceCard;

    protected BattleCard firstTarget;
    protected BattleCard secondTarget;

    public string LocalizedName()
    {
        var resolvedName = localizedName.GetLocalizedString();
        if(resolvedName.IsDone)
        {
            return resolvedName.Result;
        }
        throw new System.Exception($"Unable to localize card name for Ability");
    }

    public string LocalizedDescription()
    {
        var resolvedDesc = localizedDescription.GetLocalizedString();
        if(resolvedDesc.IsDone)
        {
            return resolvedDesc.Result;
        }
        throw new System.Exception($"Unable to localize card description for Ability");
    }

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
