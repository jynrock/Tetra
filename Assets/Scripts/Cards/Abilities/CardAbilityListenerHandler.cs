using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbilityListenerHandler : MonoBehaviour
{
    public AbilityType abilityType;
    public Card sourceCard;

    private Card target;
    private Card secondTarget;
    [SerializeField]
    private CardAbilityEvent cardAbilityEvent;
    
    public void OnCardSelected(Card card)
    {
        if(target == null)
        {
            target = card;
            if (abilityType == AbilityType.ONE_TARGET)
            {
                cardAbilityEvent.Raise(new CardAbilityEventData(sourceCard, target));
            }
        }
        else
        {
            if(card != target)
            {
                secondTarget = card;
                if(abilityType == AbilityType.TWO_TARGET)
                {
                    cardAbilityEvent.Raise(new CardAbilityEventData(sourceCard, target, secondTarget));
                }
            }
        }
    }
}
public enum AbilityType
{
    ONE_TARGET,
    TWO_TARGET
}