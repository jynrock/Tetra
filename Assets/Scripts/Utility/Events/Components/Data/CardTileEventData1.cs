using System;
using UnityEngine;

[Serializable]
public class CardTileEventData
{

	public Card card;
	public Tile tile;

	public CardTileEventData(
		Card _card,
		Tile _tile
		)
	{
		card = _card;
		tile = _tile;
	}
}