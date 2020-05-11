using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MonoBehaviourCallback : UnityEvent<MonoBehaviour>
{}

[Serializable]
public class CardCallback : UnityEvent<Card>
{}

[Serializable]
public class CardTileCallback : UnityEvent<CardTileEventData>
{}

[Serializable]
public class CardTilePlayerCallback : UnityEvent<CardTilePlayerEventData>
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
public class CardListDirectionCallBack : UnityEvent<CardListDirectionEventData>
{}