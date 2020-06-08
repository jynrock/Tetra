using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    [SerializeField]
    private List<Card> cards;

    public Card GetCard(int id)
    {
        return cards.Where(c => c.cardNumber == id).Single();
    }

    public List<Card> GetAllCards()
    {
        return cards.OrderBy(c => c.cardNumber).ToList();
    }
}
