using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card Ability/Card Boost Ability")]
public class CardBoostAbility : CardAbility
{
    [SerializeField]
    private BoostType boostType;
    public override void HandleAbility(CardAbilityEventData data)
    {
        switch(boostType)
        {
            case BoostType.Health:
                data.target.BoostHealth(data.sourceCard.attack);
                break;
            case BoostType.Attack:
                data.target.BoostAttack(data.sourceCard.attack);
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