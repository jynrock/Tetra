using System;
using UnityEngine;

[Serializable]
public class CardTilePlayerEventData
{

	public Card card;
	public Tile tile;
	public Player player;

	public CardTilePlayerEventData(
		Card _card,
		Tile _tile,
		Player _player
		)
	{
		card = _card;
		tile = _tile;
		player = _player;
	}
}