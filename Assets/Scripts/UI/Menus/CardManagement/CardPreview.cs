using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPreview : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI attackText;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private Image cardArt;
    [SerializeField]
    private GameObject top;
    [SerializeField]
    private GameObject topLeft;
    [SerializeField]
    private GameObject topRight;
    [SerializeField]
    private GameObject left;
    [SerializeField]
    private GameObject right;
    [SerializeField]
    private GameObject bottom;
    [SerializeField]
    private GameObject bottomLeft;
    [SerializeField]
    private GameObject bottomRight;

    public CardInstance instance;

    public void ClearInfo()
    {
        nameText.text = "Card Name";
        attackText.text = "99";
        healthText.text = "99";
        cardArt.sprite = null;

        top.SetActive(true);
        topLeft.SetActive(true);
        topRight.SetActive(true);
        left.SetActive(true);
        right.SetActive(true);
        bottom.SetActive(true);
        bottomLeft.SetActive(true);
        bottomRight.SetActive(true);
    }

    public void SetInfo(CardInstance cardInstance)
    {
        instance = cardInstance;

        nameText.text = cardInstance.info.LocalizedName();
        attackText.text = cardInstance.attack.ToString();
        healthText.text = cardInstance.maxHealth.ToString();
        cardArt.sprite = cardInstance.info.cardArtSprite;

        top.SetActive(cardInstance.top);
        topLeft.SetActive(cardInstance.topLeft);
        topRight.SetActive(cardInstance.topRight);
        left.SetActive(cardInstance.left);
        right.SetActive(cardInstance.right);
        bottom.SetActive(cardInstance.bottom);
        bottomLeft.SetActive(cardInstance.bottomLeft);
        bottomRight.SetActive(cardInstance.bottomRight);
    }
}
