using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "GameEvent/CardEvent")]
public class CardEvent : SubscribableAsset<Card>
{
}
