using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewIcon : MonoBehaviour
{
    [SerializeField]
    private Card card;
    [SerializeField]
    private Image image;
    [SerializeField]
    private CardEvent onCardPreviewSelectedEvent;

    public void SetCard(Card _card)
    {
        card = _card;
        image.sprite = _card.cardIcon;
    }

    public void SelectCard()
    {
        onCardPreviewSelectedEvent.Raise(card);
    }
}
