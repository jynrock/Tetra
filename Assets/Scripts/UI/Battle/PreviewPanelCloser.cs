using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewPanelCloser : MonoBehaviour
{
    [SerializeField]
    private BattlecardEvent hidePanelEvent;

    public void ClosePreviewPanel()
    {
        hidePanelEvent.Raise(null);
    }
}
