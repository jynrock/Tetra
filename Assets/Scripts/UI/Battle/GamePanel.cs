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
    public TMP_Dropdown levelSelector;

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

            foreach(string level in Database.Instance.Level.GetLevelNames())
            {
                levelSelector.options.Add(new TMP_Dropdown.OptionData("Select"));
                levelSelector.options.Add(new TMP_Dropdown.OptionData(level));
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
        LevelManager.Instance.SetTheme(levelSelector.options[levelSelector.value].text);
    }

    public void ResetOptions()
    {
        levelSelector.value = 0;
        opponentSelector.value = 0;
        LevelManager.Instance.SetOpponent(null);
        LevelManager.Instance.SetTheme(null);
    }
}
public enum Difficulty{
    Select, Chaotic
}