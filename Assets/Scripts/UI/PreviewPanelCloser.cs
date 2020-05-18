using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewPanelCloser : MonoBehaviour
{
    [SerializeField]
    private GameObject previewPanel;

    void OnMouseDown()
    {
        previewPanel.SetActive(false);
    }
}
