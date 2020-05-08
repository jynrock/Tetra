using System;
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
public class PlayerCallback : UnityEvent<Player>
{}

[Serializable]
public class BoardCallback : UnityEvent<Board>
{}