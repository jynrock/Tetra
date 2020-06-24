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
    private GameObject[] cardPositions;

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

    public void SetCardPositions(List<BattleCard> cards)
    {
        for(int i = 0; i < 5; i++)
        {
            cards[i].transform.SetParent(cardPositions[i].transform);
            cards[i].transform.localPosition = Vector3.zero;
        }
    }
}
