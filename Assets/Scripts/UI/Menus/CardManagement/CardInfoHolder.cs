using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoHolder : MonoBehaviour
{
    [SerializeField]
    private CardPreview cardPreview;
    [SerializeField]
    private TextMeshProUGUI numberText;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI typeText;
    [SerializeField]
    private TextMeshProUGUI abilityNameText;
    [SerializeField]
    private TextMeshProUGUI abilityDescText;
    [SerializeField]
    private TextMeshProUGUI descText;

    [SerializeField]
    private GameObject nextBtn;
    [SerializeField]
    private GameObject prevBtn;
    [SerializeField]
    private GameObject disabler;

    [SerializeField]
    private CardInstanceEvent tryAddCardToHandEvent;


    private List<CardInstance> cardInstances;
    private int cardIndex;

    public void SetBaseInfo(Card card)
    {
        cardIndex = 0;
        cardInstances = PlayerProfile.Instance.GetCardsFromDeck(card.cardNumber);
        cardInstances = cardInstances.Where(c => !PlayerProfile.Instance.GetHand().Contains(c)).ToList();
        
        if(cardInstances.Count == 0)
        {
            ClearInfo();
        }
        else if(cardInstances.Count > 1)
        {
            nextBtn.SetActive(true);
            prevBtn.SetActive(true);
            SetInfo();
        }
        else
        {
            nextBtn.SetActive(false);
            prevBtn.SetActive(false);
            SetInfo();
        }
    }

    public bool ShouldRefreshInfo(Card card)
    {
        if(cardInstances != null && cardInstances.Count > 0)
        {
            return cardInstances[cardIndex].info.cardNumber == card.cardNumber;
        }
        return false;
    }

    public void IncrementCard()
    {
        cardIndex++;
        if(cardIndex >= cardInstances.Count)
        {
            cardIndex = 0;
        }
        SetInfo();
    }

    public void DecrementCard()
    {
        cardIndex--;
        if(cardIndex < 0)
        {
            cardIndex = cardInstances.Count - 1;
        }
        SetInfo();
    }

    public void ClearInfo()
    {
        cardPreview.ClearInfo();

        numberText.text = "#000";
        nameText.text = "";
        typeText.text = "";
        abilityNameText.text = ":";
        abilityDescText.text = "";
        descText.text = "";

        disabler.SetActive(false);
    }

    public void TryAddCardToHand()
    {
        tryAddCardToHandEvent.Raise(cardInstances[cardIndex]);
    }

    private void SetInfo()
    {
        disabler.SetActive(true);
        CardInstance currentSelected = cardInstances[cardIndex];
        cardPreview.SetInfo(currentSelected);

        numberText.text = "#" + currentSelected.info.cardNumber.ToString("000");
        nameText.text = currentSelected.info.LocalizedName();
        typeText.text = "";
        abilityNameText.text = currentSelected.cardAbility.LocalizedName() + ":";
        abilityDescText.text = currentSelected.cardAbility.LocalizedDescription();
        descText.text = currentSelected.info.LocalizedDescription();
    }
}
