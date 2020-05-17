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

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = owner.playerName;
        nameText.color = owner.playerColor;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
