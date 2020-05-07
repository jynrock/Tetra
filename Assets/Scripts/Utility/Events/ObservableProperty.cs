using System;
using System.Collections.Generic;
using UnityEngine;

/// A property that calls the OnRaise method on all its listeners whenever its value
/// is changed
/// Also may raise a GameEvent if provided
public class ObservableProperty<T> : SubscribableAsset<T>, IEquatable<ObservableProperty<T>> where T : IEquatable<T>
{

    [Header("Optional On Change Event")]
    public GameEvent GameEvent;

    [SerializeField]
    [Header("Default Value")]
    protected T value;

    public T Value {
        get
        {
            return this.value;
        }
        set
        {
            if(!value.Equals(this.value))
            {
                this.previousValue = this.value;
                this.value = value;
                this.GameEvent?.Raise(null);
                this.Raise(this.value);
            }
        }
    }

    protected T previousValue;

    public T PreviousValue {
        get
        {
            return this.previousValue;
        }
    }

    /// Changes the value of the property without alerting its listeners
    public void SetValueWithoutNotify(T _value)
    {
        this.value = _value;
    }

    /// CHanges the value of the property and notifies regardless if the value is different
    public void SetValueNotify(T _value)
    {
        this.previousValue = this.value;
        this.value = _value;
        this.Raise(this.value);
    }

    public bool Equals(ObservableProperty<T> other)
    {
        return this.value.Equals(other.value);
    }
}
