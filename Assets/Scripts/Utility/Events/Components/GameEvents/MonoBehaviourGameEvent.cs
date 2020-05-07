using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "GameEvent/MonoBehaviour")]
public class MonoBehaviourGameEvent : SubscribableAsset<MonoBehaviour>
{
	new protected SortedSet<MonoBehaviourListener> listeners;
    protected MonoBehaviourListener[] listenersCache;

    private bool modifiedSinceLastRaise = true;

	new protected virtual void Awake()
	{
		this.listeners = new SortedSet<MonoBehaviourListener>(
            Comparer<MonoBehaviourListener>.Create(
                (a, b) => a.CompareTo(b)
            )
        );
	}

    new public virtual void Subscribe(IListener<MonoBehaviour> listener)
    {
        if(this.listeners == null)
        {
            this.listeners = new SortedSet<MonoBehaviourListener>(
                Comparer<MonoBehaviourListener>.Create(
                    (a, b) => a.CompareTo(b)
                )
            );
        }
    	this.listeners.Add((MonoBehaviourListener)listener);
        this.modifiedSinceLastRaise = true;
    }

    new public virtual void Unsubscribe(IListener<MonoBehaviour> listener)
    {
    	this.listeners.Remove((MonoBehaviourListener)listener);
        this.modifiedSinceLastRaise = true;
    }

    new public virtual void Raise(MonoBehaviour monoBehaviour)
    {
        /// Necessary in case this.listeners gets modified during the execution of the OnRaise methods
        MonoBehaviourListener[] listenersCopy;
        if(this.modifiedSinceLastRaise)
        {
            this.listenersCache = new MonoBehaviourListener[this.listeners.Count];
            this.listeners.CopyTo(this.listenersCache);
        }
        listenersCopy = this.listenersCache;

        foreach(MonoBehaviourListener listener in listenersCopy)
        {
            listener.OnRaise(monoBehaviour);
        }
    }
}
