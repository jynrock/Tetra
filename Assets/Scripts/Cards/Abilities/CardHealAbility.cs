using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Heal Ability")]
public class CardHealAbility : CardAbility
{
    public override void HandleAbility(BattlecardAbilityEventData data)
    {
        data.target.Heal(data.sourceCard.card.maxHealth);
    }
}
