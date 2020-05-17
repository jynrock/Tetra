using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattlecardListDirectionEventData
{

	public BattleCard card;
	public Dictionary<BattleCard,CardDirection> cardList;

	public BattlecardListDirectionEventData(
		BattleCard _card,
		Dictionary<BattleCard,CardDirection> _list
		)
	{
		card = _card;
		cardList = _list;
	}
}