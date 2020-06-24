using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandDisplay : MonoBehaviour
{
    public Player owner;

    public List<GameObject> fakeCards;

    [SerializeField]
    private TextMeshPro nameText;
    [SerializeField]
    private SpriteRenderer playerIcon;

    public void OnGameLoaded(bool loaded)
    {
        if (loaded)
        {
            UpdateDisplay();
        }
    }

    public void OnPlayCard(BattlecardTilePlayerEventData data)
    {
        if( data.player == owner)
        {
            GameObject fakeCard = fakeCards[fakeCards.Count - 1];
            fakeCards.Remove(fakeCard);
            Destroy(fakeCard);
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
