using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "GameEvent/PlayerEvent")]
public class PlayerEvent : SubscribableAsset<Player>
{
}
