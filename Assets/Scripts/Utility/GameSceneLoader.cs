using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSceneLoader : MonoBehaviour
{
    [SerializeField]
    private BoolGameEvent gameSceneLoadedEvent;
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private BattleCard battleCardPrefab;
    [SerializeField]
    private HumanPlayer humanPlayer;
    [SerializeField]
    private PlayerEvent announcePlayerEvent;
    [SerializeField]
    private AIPlayer aIPlayer;
    [SerializeField]
    private BattlecardTileEvent tryPlayCardEvent;

    private List<BattleCard> playerBattleCards;
    private List<BattleCard> aiBattleCards;

    void Start()
    {
        StartCoroutine(LoadGameScene());
    }


    private IEnumerator LoadGameScene()
    {
        yield return null;
        // load logic goes here
        SetUpHumanPlayerBattleCards();
        SetUpHumanPlayerObject();
        SetUpAIPlayerBattleCards();
        SetUpAIPlayerObject();
        yield return new WaitForSeconds(1.0f);
        gameSceneLoadedEvent.Raise(true);
        Destroy(gameObject);
    }

    private void SetUpHumanPlayerBattleCards()
    {
        playerBattleCards = new List<BattleCard>();
        PlayerHandDisplay playerHand = PlayerProfile.Instance.GetLeftyMode() ? 
            leftHand.GetComponent<PlayerHandDisplay>() : rightHand.GetComponent<PlayerHandDisplay>();
        foreach(CardInstance cardInstance in PlayerProfile.Instance.GetHand())
        {
            BattleCard card = Instantiate(battleCardPrefab);
            card.SetCardInstance(cardInstance);
            playerBattleCards.Add(card);
        }
        playerHand.SetCardPositions(playerBattleCards);
        playerHand.SetOwner(humanPlayer);
    }

    private void SetUpHumanPlayerObject()
    {
        humanPlayer.SetData(PlayerProfile.Instance.GetPlayerName(), PlayerProfile.Instance.GetPlayerColor(), PlayerProfile.Instance.GetPlayerAvatar(), playerBattleCards);
        announcePlayerEvent.Raise(humanPlayer);
    }

    private void SetUpAIPlayerBattleCards()
    {
        AIData aiData = LevelManager.Instance.GetOpponent();
        aiBattleCards = new List<BattleCard>();
        foreach(CardInstance cardInstance in aiData.aIDeck)
        {
            BattleCard card = Instantiate(battleCardPrefab);
            card.SetCardInstance(cardInstance);
            aiBattleCards.Add(card);
        }
    }

    private void SetUpAIPlayerObject()
    {
        AIData aiData = LevelManager.Instance.GetOpponent();
        aIPlayer.SetData(aiData.aIName, aiData.aIColor, aiData.aIIcon, aiBattleCards);
        Type aiBaseType = aiData.aIBaseType;
        AIBase aiBase = (AIBase)aIPlayer.gameObject.AddComponent(aiBaseType);
        aIPlayer.SetAIBase(aiBase, tryPlayCardEvent);
    }
}
