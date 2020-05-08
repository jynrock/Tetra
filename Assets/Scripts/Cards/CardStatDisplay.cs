using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardStatDisplay : MonoBehaviour
{
    [SerializeField]
    private Card card;

    [SerializeField]
    private TextMeshPro healthText;
    [SerializeField]
    private TextMeshPro nameText;
    [SerializeField]
    private TextMeshPro attackText;
    [SerializeField]
    private TextMeshPro defenseText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = card.health.ToString();
        nameText.text = card.cardName;
        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
