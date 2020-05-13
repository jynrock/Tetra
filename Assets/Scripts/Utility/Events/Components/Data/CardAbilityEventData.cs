using System;
using UnityEngine;

[Serializable]
public class CardAbilityEventData
{
	public Card sourceCard;
	public Card target;
	public Card secondTarget;

	public CardAbilityEventData(
		Card _source,
		Card _target,
		Card _secondTarget = null
		)
	{
		sourceCard = _source;
		target = _target;
		secondTarget = _secondTarget;
	}
}