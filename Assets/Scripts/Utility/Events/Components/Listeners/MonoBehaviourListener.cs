using System;
using UnityEngine;
using UnityEngine.Events;

/// Listener that has a Callback that is invoked when the
/// subcribed MonoBehaviourGameEvent is raised
public class MonoBehaviourListener : MonoBehaviour, IListener<MonoBehaviour>, IComparable
{
    [SerializeField] public MonoBehaviourGameEvent target;
    [SerializeField] private MonoBehaviourCallback callback;

    [SerializeField] protected int priority;
    public int Priority { get => this.priority; }

    void OnEnable()
    {
        this.target.Subscribe(this);
    }

    void OnDisable()
    {
        this.target.Unsubscribe(this);
    }

    public void OnRaise(MonoBehaviour data)
    {
        this.callback.Invoke(data);
    }

    public int CompareTo(object obj) {
        if(obj == null)
        {
            return 1;
        }
        MonoBehaviourListener other = obj as MonoBehaviourListener;
        if(this.Priority > other.Priority)
        {
            return -1;
        }
        return 1;
    }
}
