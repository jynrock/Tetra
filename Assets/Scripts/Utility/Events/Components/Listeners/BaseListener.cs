using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Base class for MonoBehavior-based event-listeners
public abstract class BaseListener<T> : MonoBehaviour, IListener<T>
{

    [SerializeField] protected ScriptableObject target;
    public virtual SubscribableAsset<T> Target { get => (SubscribableAsset<T>) this.target; }

    void OnEnable()
    {
        this.Target.Subscribe(this);
    }

    void OnDisable()
    {
        this.Target.Unsubscribe(this);
    }

    public abstract void OnRaise(T data);
}
