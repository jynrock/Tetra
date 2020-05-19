using System;
using System.Collections;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Boost Ability")]
public class CardBoostAbility : CardAbility
{
    [SerializeField]
    private BoostType boostType;

    public override void OnTargetSelected(BattleCard card)
    {
        if(card.tile != null)
        {
            firstTarget = card;
            tryUseAbilityEvent.Raise(new BattlecardAbilityEventData() {sourceCard = sourceCard, abilityBeingUsed = this, type = type, target = firstTarget});
        }
        else
        {
            Deactivate();
        }
    }

    public override IEnumerator HandleAbility(BattlecardAbilityEventData data)
    {
        yield return null;
        switch(boostType)
        {
            case BoostType.Health:
                data.target.BoostHealth(data.sourceCard.card.attack);
                break;
            case BoostType.Attack:
                data.target.BoostAttack(data.sourceCard.card.attack);
                break;
            default:
                break;
        }
    }
    private enum BoostType
    {
        Health,
        Attack
    }
}