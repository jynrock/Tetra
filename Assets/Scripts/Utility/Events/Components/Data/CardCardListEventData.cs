using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardListDirectionEventData
{

	public Card card;
	public Dictionary<Card,CardDirection> cardList;

	public CardListDirectionEventData(
		Card _card,
		Dictionary<Card,CardDirection> _list
		)
	{
		card = _card;
		cardList = _list;
	}
}