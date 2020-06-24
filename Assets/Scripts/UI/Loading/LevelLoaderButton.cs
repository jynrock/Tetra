using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderButton : MonoBehaviour
{
    public void LoadLevel(string toLoad)
    {
        LevelManager.Instance.LoadLevel(toLoad);
    }

    public void LoadBattleLevel()
    {
        LevelManager.Instance.LoadBattleLevel();
    }
}
