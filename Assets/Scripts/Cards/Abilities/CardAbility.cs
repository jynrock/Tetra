using System;
using UnityEngine;

public abstract class CardAbility : ScriptableObject
{
    public string abilityName = "New Ability";
    public string abilityDescription = "New Ability Description";
    public AbilityType type;

    [SerializeField]
    private BoolGameEvent targetListeningEvent;
    [SerializeField]
    private CardAbilityEvent tryUseAbilityEvent;

    private Card sourceCard;

    private Card firstTarget;
    private Card secondTarget;

    public void Activate(Card _sourceCard)
    {
        sourceCard = _sourceCard;
        targetListeningEvent.Raise(true);
    }

    public void Deactivate()
    {
        targetListeningEvent.Raise(false);
        ResetAbility();
    }

    public void OnTargetSelected(Card card)
    {
        if(firstTarget == null)
        {
            firstTarget = card;
            if (type == AbilityType.ONE_TARGET)
            {
                tryUseAbilityEvent.Raise(new CardAbilityEventData() {sourceCard = sourceCard, type = type, target = firstTarget});
                ResetAbility();
            }
        }
        else
        {
            if(card != firstTarget)
            {
                secondTarget = card;
                if(type == AbilityType.TWO_TARGET)
                {
                    tryUseAbilityEvent.Raise(new CardAbilityEventData() {sourceCard = sourceCard, type = type, target = firstTarget, secondTarget = secondTarget});
                    ResetAbility();
                }
            }
        }
    }

    public void ResetAbility()
    {
        sourceCard = null;
        firstTarget = null;
        secondTarget = null;
    }

    public abstract void HandleAbility(CardAbilityEventData data);
}
