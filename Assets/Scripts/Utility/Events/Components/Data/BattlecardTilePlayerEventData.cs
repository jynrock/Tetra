using System;
using UnityEngine;

[Serializable]
public class BattlecardTilePlayerEventData
{

	public BattleCard card;
	public Tile tile;
	public Player player;

	public BattlecardTilePlayerEventData(
		BattleCard _card,
		Tile _tile,
		Player _player
		)
	{
		card = _card;
		tile = _tile;
		player = _player;
	}
}