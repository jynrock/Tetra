using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ViewManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI gameResultText;
    [SerializeField]
    private GameObject gameOverTextHolder;
    [SerializeField]
    private ScoreRow scoreRow;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject previewPane;
    [SerializeField]
    private CardDisplay cardPreview;
    [SerializeField]
    private GameObject cardPreviewCloser;

    void OnMouseDown()
    {
        Debug.Log("test");
    }

    public void OnStartGameOver(Dictionary<Player, int> data)
    {
        var sortedData = data.OrderByDescending(kvp => kvp.Value);

        if(AnyTwoEqual(sortedData.Select(pair => pair.Value).ToList()))
        {
            gameResultText.text = "Draw!";
        }
        else
        {
            if (sortedData.First().Key is HumanPlayer)
            {
                gameResultText.text = "You win!";
            }
            else
            {
                gameResultText.text = "You lose.";
            }
        }
        foreach(KeyValuePair<Player, int> pair in sortedData)
        {
            ScoreRow sr = Instantiate(scoreRow);
            sr.transform.SetParent(gameOverTextHolder.transform);
            sr.SetText(pair.Key.playerName, pair.Value);
        }
        gameOverPanel.SetActive(true);
    }
    
    private bool AnyTwoEqual(List<int> ints)
    {
        for (int i = 0; i < ints.Count-1; i++)
        {
            for (int j = i+1; j < ints.Count; j++)
            {
                if(ints[i] == ints[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void OnShowPreviewPane(BattleCard card)
    {
        cardPreview.SetCard(card);
        cardPreviewCloser.SetActive(true);
        previewPane.SetActive(true);
    }

    public void OnHidePreviewPane(BattleCard card)
    {
        previewPane.SetActive(false);
        cardPreviewCloser.SetActive(false);
    }
}
