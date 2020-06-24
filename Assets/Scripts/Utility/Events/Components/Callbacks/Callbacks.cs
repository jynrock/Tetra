using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MonoBehaviourCallback : UnityEvent<MonoBehaviour>
{}

[Serializable]
public class BattleCardCallback : UnityEvent<BattleCard>
{}

[Serializable]
public class BattlecardTileCallback : UnityEvent<BattlecardTileEventData>
{}

[Serializable]
public class BattlecardTilePlayerCallback : UnityEvent<BattlecardTilePlayerEventData>
{}

[Serializable]
public class PlayerCallback : UnityEvent<Player>
{}

[Serializable]
public class PlayerIntCallback : UnityEvent<Dictionary<Player, int>>
{}

[Serializable]
public class BoardCallback : UnityEvent<Board>
{}

[Serializable]
public class BattlecardListDirectionCallBack : UnityEvent<BattlecardListDirectionEventData>
{}

[Serializable]
public class BattlecardAbilityEventCallBack : UnityEvent<BattlecardAbilityEventData>
{}

[Serializable]
public class CardEventCallBack : UnityEvent<Card>
{}

[Serializable]
public class CardInstanceEventCallBack  : UnityEvent<CardInstance>
{}