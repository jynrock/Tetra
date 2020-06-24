using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManagementPanel : MonoBehaviour
{
    [SerializeField]
    private CardInfoHolder cardInfoHolder;
    [SerializeField]
    private HandHolder handHolder;
    [SerializeField]
    private GameObject deckHolder;
    [SerializeField]
    private PreviewIcon previewIconPrefab;
    private List<PreviewIcon> icons;

    public void SetCardList()
    {
        RefreshDeck();

        handHolder.InitializeHandDisplay();
    }

    public void RefreshDeck()
    {
        ClearCardList();

        List<CardInstance> deck = PlayerProfile.Instance.GetDeck();
        List<Card> cards = deck.Where(c => !PlayerProfile.Instance.GetHand().Contains(c)).Select(c => c.info).Distinct().OrderBy(c => c.cardNumber).ToList();
        foreach(Card card in cards)
        {
            PreviewIcon iconInst = Instantiate(previewIconPrefab);
            iconInst.SetCard(card);
            iconInst.transform.SetParent(deckHolder.transform);
            icons.Add(iconInst);
        }
    }
    
    public void SetPreviewBaseInfo(Card card)
    {
        cardInfoHolder.SetBaseInfo(card);
    }

    public void AddCardToHand(CardInstance card)
    {
        if(PlayerProfile.Instance.AddToHand(card))
        {
            RefreshDeck();
            cardInfoHolder.SetBaseInfo(card.info);
            handHolder.UpdateHandDisplay();
        }
    }

    public void RemoveCardFromHand(CardInstance card)
    {
        if(PlayerProfile.Instance.RemoveFromHand(card))
        {
            RefreshDeck();
            if(cardInfoHolder.ShouldRefreshInfo(card.info))
            {
                cardInfoHolder.SetBaseInfo(card.info);
            }
            handHolder.UpdateHandDisplay();
        }
    }

    private void ClearCardList()
    {
        if(icons != null)
        {
            foreach(PreviewIcon icon in icons)
            {
                Destroy(icon.gameObject);
            }
        }
        icons = new List<PreviewIcon>();
    }
}
