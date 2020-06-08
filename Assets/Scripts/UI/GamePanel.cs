using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown difficultySelector;
    [SerializeField]
    public TMP_Dropdown themeSelector;

    private bool optionsSet;

    public void SetOptions()
    {
        if(!optionsSet)
        {
            foreach(Difficulty diff in Enum.GetValues(typeof(Difficulty)))
            {
                difficultySelector.options.Add(new TMP_Dropdown.OptionData(diff.ToString()));
            }

            foreach(Theme theme in Enum.GetValues(typeof(Theme)))
            {
                themeSelector.options.Add(new TMP_Dropdown.OptionData(theme.ToString()));
            }
            optionsSet = true;
        }
    }

    public void SetDifficulty()
    {
        LevelManager.Instance.SetDifficulty((Difficulty)difficultySelector.value);
    }

    public void SetTheme()
    {
        LevelManager.Instance.SetTheme((Theme)themeSelector.value);
    }

    public void ResetOptions()
    {
        themeSelector.value = 0;
        difficultySelector.value = 0;
        LevelManager.Instance.SetDifficulty(Difficulty.Select);
        LevelManager.Instance.SetTheme(Theme.Select);
    }
}
public enum Difficulty{
    Select, Chaotic
}

public enum Theme
{
    Select, Tavern
}