using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    private static DialogueManager _instance;
    public static DialogueManager Instance { get {return _instance;} }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField]
    private DialoguePanel panelPrefab;

    public void Show(DialogueSet dialogueSet){
        DialoguePanel panelInst = Instantiate(panelPrefab);
        panelInst.transform.SetParent(transform, false);
        panelInst.Setup(dialogueSet);
    }
}
