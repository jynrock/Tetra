using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Card/Card")]
public class Card : ScriptableObject
{
    public int cardNumber;
    [SerializeField]
    private LocalizedString localizedName;
    [SerializeField]
    private LocalizedString localizedDescription;
    public int type;
    public Material cardArt;
    public Sprite cardIcon;
    public Sprite cardArtSprite;


    public string LocalizedName()
    {
        var resolvedName = localizedName.GetLocalizedString();
        if(resolvedName.IsDone)
        {
            return resolvedName.Result;
        }
        Debug.Log($"Unable to localize card name for ID {cardNumber}");
        return resolvedName.Result;
    }

    public string LocalizedDescription()
    {
        var resolvedDesc = localizedDescription.GetLocalizedString();
        if(resolvedDesc.IsDone)
        {
            return resolvedDesc.Result;
        }
        Debug.Log($"Unable to localize card description for ID {cardNumber}");
        return resolvedDesc.Result;
    }
}
