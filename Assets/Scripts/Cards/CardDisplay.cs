using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
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
    private MeshRenderer frame;
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

        topArrow.SetActive(card.top);
        topRightArrow.SetActive(card.topRight);
        topLeftArrow.SetActive(card.topLeft);
        leftArrow.SetActive(card.left);
        rightArrow.SetActive(card.right);
        bottomLeftArrow.SetActive(card.bottomLeft);
        bottomRightArrow.SetActive(card.bottomRight);
        bottomArrow.SetActive(card.bottom);
    }

    // Update is called once per frame
    void Update()
    {
        
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
