using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandHolder : MonoBehaviour
{
    [SerializeField]
    private CardPreview[] handLocations;
    [SerializeField]
    private CardPreview previewPrefab;

    private List<CardInstance> currentHand;

    public void InitializeHandDisplay()
    {
        currentHand = PlayerProfile.Instance.GetHand();

        UpdateHandDisplay();
    }

    public void UpdateHandDisplay()
    {
        currentHand = PlayerProfile.Instance.GetHand();

        foreach (CardPreview preview in handLocations)
        {
            preview.gameObject.SetActive(false);
        }

        int i = 0;
        foreach(CardInstance card in currentHand)
        {
            handLocations[i].gameObject.SetActive(true);
            handLocations[i].SetInfo(card);
            i++;
        }
    }
}
