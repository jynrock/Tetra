using System;
using UnityEngine;

[Serializable]
public class BattlecardTileEventData
{

	public BattleCard card;
	public Tile tile;

	public BattlecardTileEventData(
		BattleCard _card,
		Tile _tile
		)
	{
		card = _card;
		tile = _tile;
	}
}