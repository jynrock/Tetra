using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "GameEvent/BoardEvent")]
public class BoardEvent : SubscribableAsset<Board>
{
}
