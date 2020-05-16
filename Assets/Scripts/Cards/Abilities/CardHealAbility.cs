using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card Ability/Card Heal Ability")]
public class CardHealAbility : CardAbility
{
    public override void HandleAbility(CardAbilityEventData data)
    {
        data.target.Heal(data.sourceCard.maxHealth);
    }
}
