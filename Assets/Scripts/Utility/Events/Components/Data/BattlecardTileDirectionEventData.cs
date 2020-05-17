using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardTileDirectionEventData
{

	public BattleCard card;
	Dictionary<BattleCard, CardDirection> cardsToAttack;

	public CardTileDirectionEventData(
		BattleCard _card,
		Dictionary<BattleCard, CardDirection> _toAttack
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