using System;
using UnityEngine;

[Serializable]
public class CardAbilityEventData
{
	public Card sourceCard;
	public AbilityType type;
	public Card target;
	public Card secondTarget;
}
public enum AbilityType
{
	ONE_TARGET,
	TWO_TARGET
}