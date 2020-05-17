using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Boost Ability")]
public class CardBoostAbility : CardAbility
{
    [SerializeField]
    private BoostType boostType;
    public override void HandleAbility(BattlecardAbilityEventData data)
    {
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