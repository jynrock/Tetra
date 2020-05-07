using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MonoBehaviourCallback : UnityEvent<MonoBehaviour>
{}

[Serializable]
public class CardCallback : UnityEvent<Card>
{}