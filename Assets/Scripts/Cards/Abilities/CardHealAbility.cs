using System;
using System.Collections;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Heal Ability")]
public class CardHealAbility : CardAbility
{
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
        data.target.Heal(data.sourceCard.card.maxHealth);
    }
}
