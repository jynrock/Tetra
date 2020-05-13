using System;
using UnityEngine;

public abstract class CardAbility : ScriptableObject
{
    public string abilityName = "New Ability";
    public string abilityDescription = "New Ability Description";
    [SerializeField]
    private CardAbilityListenerHandler abilityListenerHandler;

    [SerializeField]
    protected CardAbilityListenerHandler instantiatedAbilityListener;

    public void Activate(Card _sourceCard)
    {
        instantiatedAbilityListener = Instantiate(abilityListenerHandler).GetComponent<CardAbilityListenerHandler>();
        SetupListener(_sourceCard);
    }

    public void Deactivate()
    {
        if(instantiatedAbilityListener != null)
        {
            Destroy(instantiatedAbilityListener.gameObject);
            instantiatedAbilityListener = null;
        }
    }

    public abstract void SetupListener(Card card);
    public abstract void HandleAbility(CardAbilityEventData data);
}
