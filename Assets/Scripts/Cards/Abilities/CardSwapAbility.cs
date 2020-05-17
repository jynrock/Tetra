using System;
using System.Collections;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Card/Card Ability/Card Swap Ability")]
public class CardSwapAbility : CardAbility
{
    public override IEnumerator HandleAbility(BattlecardAbilityEventData data)
    {
        yield return null;
        Tile firstTile = data.target.tile;
        Tile secondTile = data.secondTarget.tile;

        float journey = 0f;
        float duration = 0.15f;
        Vector3 originOne = data.target.transform.position;
        Vector3 targetOne = data.secondTarget.transform.position;
        Vector3 originTwo = data.secondTarget.transform.position;
        Vector3 targetTwo = data.target.transform.position;
        while(journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);
            data.target.transform.position = Vector3.Lerp(originOne, targetOne, percent);
            data.secondTarget.transform.position = Vector3.Lerp(originTwo, targetTwo, percent);
            yield return null;
        }
        data.target.tile = secondTile;
        secondTile.SetCard(data.target);
        data.secondTarget.tile = firstTile;
        firstTile.SetCard(data.secondTarget);
    }
}
