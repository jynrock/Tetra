using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRemoveButton : MonoBehaviour
{
    [SerializeField]
    private CardPreview preview;
    [SerializeField]
    private CardManagementPanel panel;

    public void RemoveFromHand()
    {
        panel.RemoveCardFromHand(preview.instance);
    }
}
