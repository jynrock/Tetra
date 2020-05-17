using System;
using System.Collections;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Boost Ability")]
public class CardBoostAbility : CardAbility
{
    [SerializeField]
    private BoostType boostType;
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