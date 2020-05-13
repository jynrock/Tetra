using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    [SerializeField]
    private TextMeshPro healthText;
    [SerializeField]
    private TextMeshPro nameText;
    [SerializeField]
    private TextMeshPro attackText;
    [SerializeField]
    private MeshRenderer frame;
    [SerializeField]
    private MeshRenderer cardArt;
    [SerializeField]
    private GameObject topLeftArrow;
    [SerializeField]
    private GameObject topArrow;
    [SerializeField]
    private GameObject topRightArrow;
    [SerializeField]
    private GameObject leftArrow;
    [SerializeField]
    private GameObject rightArrow;
    [SerializeField]
    private GameObject bottomLeftArrow;
    [SerializeField]
    private GameObject bottomRightArrow;
    [SerializeField]
    private GameObject bottomArrow;
    [SerializeField]
    private TextMeshPro specialAbilityText;
    [SerializeField]
    private GameObject abilityPreviewPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(card != null)
        {
            SetAll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCard(Card c)
    {
        card = c;

        SetAll();
        SetPlayerColor();
    }

    public void SetAll()
    {
        healthText.text = card.health.ToString();
        nameText.text = card.cardName;
        attackText.text = card.attack.ToString();
        cardArt.material = card.cardArt;

        topArrow.SetActive(card.top);
        topRightArrow.SetActive(card.topRight);
        topLeftArrow.SetActive(card.topLeft);
        leftArrow.SetActive(card.left);
        rightArrow.SetActive(card.right);
        bottomLeftArrow.SetActive(card.bottomLeft);
        bottomRightArrow.SetActive(card.bottomRight);
        bottomArrow.SetActive(card.bottom);

        if(abilityPreviewPanel != null)
        {
            if(card.cardAbility != null)
            {
                abilityPreviewPanel.SetActive(true);
                specialAbilityText.text = card.cardAbility.abilityName + "\n" + card.cardAbility.abilityDescription;
            }
            else
            {
                abilityPreviewPanel.SetActive(false);
            }
        }
    }

    public void SetPlayerColor()
    {
        frame.material.color = card.currentOwner.playerColor;
    }

    public void UpdateStats()
    {
        healthText.text = card.health.ToString();
        frame.material.color = card.currentOwner.playerColor;
    }
}
