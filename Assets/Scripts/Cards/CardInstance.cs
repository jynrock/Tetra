using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardInstance")]
public class CardInstance : ScriptableObject
{
    public Card info;
    public int health;
    public int maxHealth;
    public int attack;
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
