using System;
using UnityEngine.Events;

[Serializable]
public class BoolCallback : UnityEvent<bool>
{}

[Serializable]
public class FloatCallback : UnityEvent<float>
{}

[Serializable]
public class StringCallback : UnityEvent<string>
{}

[Serializable]
public class IntCallback : UnityEvent<int>
{}