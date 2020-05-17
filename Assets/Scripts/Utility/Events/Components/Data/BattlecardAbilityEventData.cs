using System;
using UnityEngine;

[Serializable]
public class BattlecardAbilityEventData
{
	public BattleCard sourceCard;
	public AbilityType type;
	public BattleCard target;
	public BattleCard secondTarget;
}
public enum AbilityType
{
	ONE_TARGET,
	TWO_TARGET
}