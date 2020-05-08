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

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = card.health.ToString();
        nameText.text = card.cardName;
        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();

        topArrow.SetActive(card.arrows.top.Value);
        topRightArrow.SetActive(card.arrows.topRight.Value);
        topLeftArrow.SetActive(card.arrows.topLeft.Value);
        leftArrow.SetActive(card.arrows.left.Value);
        rightArrow.SetActive(card.arrows.right.Value);
        bottomLeftArrow.SetActive(card.arrows.bottomLeft.Value);
        bottomRightArrow.SetActive(card.arrows.bottomRight.Value);
        bottomArrow.SetActive(card.arrows.bottom.Value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
