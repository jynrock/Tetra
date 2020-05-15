using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card Ability/Card Swap Ability")]
public class CardSwapAbility : CardAbility
{
    public override void HandleAbility(CardAbilityEventData data)
    {
        Tile firstTile = data.target.tile;
        Tile secondTile = data.secondTarget.tile;
        data.target.tile = secondTile;
        secondTile.SetCard(data.target);
        data.secondTarget.tile = firstTile;
        firstTile.SetCard(data.secondTarget);
    }
}
