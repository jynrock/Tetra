using System;
using System.Collections;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Heal Ability")]
public class CardHealAbility : CardAbility
{
    public override IEnumerator HandleAbility(BattlecardAbilityEventData data)
    {
        yield return null;
        data.target.Heal(data.sourceCard.card.maxHealth);
    }
}
