using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Reset Ability")]
public class CardResetAbility : CardAbility
{
    public override void HandleAbility(BattlecardAbilityEventData data)
    {
        data.target.cardAbilityUsed = false;
    }
}
