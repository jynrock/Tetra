using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    private static Database _instance;
    public static Database Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        if (_instance == null || _instance != this)
        {
            _instance = this;
        }
    }

    public CardDatabase Card;
    public ThemeDatabase Theme;
    public AIDatabase AI;
}
