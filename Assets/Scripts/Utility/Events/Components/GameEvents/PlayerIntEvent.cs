using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "GameEvent/PlayerIntEvent")]
public class PlayerIntEvent : SubscribableAsset<Dictionary<Player, int>>
{
}
