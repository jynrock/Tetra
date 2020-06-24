using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "AI/AIData")]
public class AIData : ScriptableObject
{
    public Difficulty aIDifficulty;
    public Type aIBaseType;
    public string aIName;
    public CardInstance[] aIDeck;
    public Color aIColor;
    public Sprite aIIcon;
}
