using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Card")]
public class Card : ScriptableObject
{
    public int cardNumber;
    public string cardName;
    public string cardDesc;
    public int type;
    public Material cardArt;
}
