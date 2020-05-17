using System;
using System.Collections;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Reset Ability")]
public class CardResetAbility : CardAbility
{
    public override IEnumerator HandleAbility(BattlecardAbilityEventData data)
    {
        yield return null;
        data.target.cardAbilityUsed = false;
    }
}
