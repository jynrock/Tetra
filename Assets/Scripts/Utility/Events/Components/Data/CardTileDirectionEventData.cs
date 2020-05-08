using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardTileDirectionEventData
{

	public Card card;
	Dictionary<Card, CardDirection> cardsToAttack;

	public CardTileDirectionEventData(
		Card _card,
		Dictionary<Card, CardDirection> _toAttack
		)
	{
		card = _card;
		cardsToAttack = _toAttack;
	}
}

public enum CardDirection
{
	topLeft,
	top,
	topRight,
	right,
	bottomRight,
	bottom,
	bottomLeft,
	left
}