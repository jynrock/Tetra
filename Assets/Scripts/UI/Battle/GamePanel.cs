using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown opponentSelector;
    [SerializeField]
    public TMP_Dropdown themeSelector;

    private bool optionsSet;

    public void SetOptions()
    {
        if(!optionsSet)
        {
            opponentSelector.options.Add(new TMP_Dropdown.OptionData("Select"));
            foreach(AIData aiData in Database.Instance.AI.GetAll())
            {
                opponentSelector.options.Add(new TMP_Dropdown.OptionData(aiData.aIName));
            }

            foreach(Theme theme in Enum.GetValues(typeof(Theme)))
            {
                themeSelector.options.Add(new TMP_Dropdown.OptionData(theme.ToString()));
            }
            optionsSet = true;
        }
    }

    public void SetOpponent()
    {
        if(opponentSelector.value > 0)
        {
            LevelManager.Instance.SetOpponent(Database.Instance.AI.GetAI(opponentSelector.value - 1));
        }
        else
        {
            LevelManager.Instance.SetOpponent(null);
        }
    }

    public void SetTheme()
    {
        LevelManager.Instance.SetTheme((Theme)themeSelector.value);
    }

    public void ResetOptions()
    {
        themeSelector.value = 0;
        opponentSelector.value = 0;
        LevelManager.Instance.SetOpponent(null);
        LevelManager.Instance.SetTheme(Theme.Select);
    }
}
public enum Difficulty{
    Select, Chaotic
}

public enum Theme
{
    Select, Debug, Tavern
}