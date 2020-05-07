using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardArrows", menuName = "ScriptableObjects/CardArrows", order = 1)]
public class CardArrows : ScriptableObject
{
    public BoolProperty topLeft;
    public BoolProperty top;
    public BoolProperty topRight;
    public BoolProperty left;
    public BoolProperty right;
    public BoolProperty bottomLeft;
    public BoolProperty bottom;
    public BoolProperty bottomRight;
}
