using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHandDisplay : MonoBehaviour
{
    public Player owner;

    [SerializeField]
    private TextMeshPro nameText;
    [SerializeField]
    private SpriteRenderer playerIcon;
    [SerializeField]
    private GameObject[] cardPositions;

    public void OnGameLoaded(bool loaded)
    {
        if (loaded)
        {
            UpdateDisplay();
        }
    }

    public void SetCardPositions(List<BattleCard> cards)
    {
        for(int i = 0; i < 5; i++)
        {
            cards[i].transform.SetParent(cardPositions[i].transform);
            cards[i].transform.localPosition = Vector3.zero;
        }
    }

    private void UpdateDisplay()
    {
        nameText.text = owner.playerName;
        nameText.color = owner.playerColor;
        float ratio = playerIcon.sprite.bounds.size.x / owner.playerIcon.bounds.size.x;
        playerIcon.sprite = owner.playerIcon;
        playerIcon.transform.localScale = new Vector3(ratio * 0.66f, ratio * 0.66f, 1);
    }
}
