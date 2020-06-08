using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneLoader : MonoBehaviour
{
    [SerializeField]
    private BoolGameEvent gameSceneLoadedEvent;
    [SerializeField]
    private GameObject standardLevelObjects;
    [SerializeField]
    private HumanPlayer humanPlayer;
    [SerializeField]
    private AIPlayer aIPlayer;
    [SerializeField]
    private BattlecardTileEvent tryPlayCardEvent;

    void Start()
    {
        StartCoroutine(LoadGameScene());
    }


    private IEnumerator LoadGameScene()
    {
        yield return null;
        // load logic goes here
        SetUpLevelTheme();
        SetUpHumanPlayerObject();
        SetUpAIPlayerObject();
        standardLevelObjects.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gameSceneLoadedEvent.Raise(true);
        Destroy(gameObject);
    }

    private void SetUpLevelTheme()
    {
        GameObject themeDressing = Database.Instance.Theme.GetThemePrefab(LevelManager.Instance.GetCurrentTheme());
        Instantiate(themeDressing);
    }

    private void SetUpHumanPlayerObject()
    {
        humanPlayer.SetData(PlayerProfile.Instance.playerName, PlayerProfile.Instance.playerColor);
    }

    private void SetUpAIPlayerObject()
    {
        AIData aiData = LevelManager.Instance.GetOpponent();
        aIPlayer.SetData(aiData.aIName, aiData.aIColor);
        Type aiBaseType = aiData.aIBaseType;
        AIBase aiBase = (AIBase)aIPlayer.gameObject.AddComponent(aiBaseType);
        aIPlayer.SetAIBase(aiBase, tryPlayCardEvent);
    }
}
