using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card Ability/Card Reset Ability")]
public class CardResetAbility : CardAbility
{
    public override void HandleAbility(CardAbilityEventData data)
    {
        data.target.cardAbilityUsed = false;
    }
}
