using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Card")]
public class Card : ScriptableObject
{
    public int cardNumber;
    public string cardName;
    public string cardDesc;
    public int health;
    public int maxHealth;
    public int type;
    public int attack;
    public Material cardArt;
    public CardAbility cardAbility;

    public bool topLeft;
    public bool top;
    public bool topRight;
    public bool left;
    public bool right;
    public bool bottomLeft;
    public bool bottom;
    public bool bottomRight;

    public int level;
    public int experience;
    public int toNextLevel;
}
