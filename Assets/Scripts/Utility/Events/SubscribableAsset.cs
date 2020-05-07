using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Base class for subscribable Scriptable Objects
[Serializable]
public abstract class SubscribableAsset<T> : ScriptableObject, ISubscribable<T>
{

	protected ISet<IListener<T>> listeners = new HashSet<IListener<T>>();

	protected virtual void Awake()
	{
		this.listeners = new HashSet<IListener<T>>();
	}

    public virtual void Subscribe(IListener<T> listener)
    {
    	this.listeners.Add(listener);
    }

    public virtual void Unsubscribe(IListener<T> listener)
    {
    	this.listeners.Remove(listener);
    }

    public virtual void Raise(T data)
    {
        foreach(IListener<T> listener in this.listeners)
        {
            listener.OnRaise(data);
        }
    }
}
