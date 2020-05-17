using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public BattleCard card;

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
    private TextMeshPro specialAbilityTitleText;
    [SerializeField]
    private TextMeshPro specialAbilityDescriptionText;
    [SerializeField]
    private GameObject abilityPreviewPanel;
    [SerializeField]
    private GameObject outline;

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

    public void SetCard(BattleCard c)
    {
        card = c;

        SetAll();
        SetPlayerColor();
    }

    public void SetAll()
    {
        healthText.text = card.card.health.ToString();
        nameText.text = card.card.cardName;
        attackText.text = card.card.attack.ToString();
        cardArt.material = card.card.cardArt;

        topArrow.SetActive(card.card.top);
        topRightArrow.SetActive(card.card.topRight);
        topLeftArrow.SetActive(card.card.topLeft);
        leftArrow.SetActive(card.card.left);
        rightArrow.SetActive(card.card.right);
        bottomLeftArrow.SetActive(card.card.bottomLeft);
        bottomRightArrow.SetActive(card.card.bottomRight);
        bottomArrow.SetActive(card.card.bottom);

        if(abilityPreviewPanel != null)
        {
            if(card.card.cardAbility != null)
            {
                abilityPreviewPanel.SetActive(true);
                specialAbilityTitleText.text = card.card.cardAbility.abilityName;
                specialAbilityDescriptionText.text = card.card.cardAbility.abilityDescription;
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
        attackText.text = card.card.attack.ToString();
        healthText.text = card.card.health.ToString();
        frame.material.color = card.currentOwner.playerColor;
    }

    public void ToggleOutline(bool shouldShowOutline)
    {
        outline.SetActive(shouldShowOutline);
    }
}
