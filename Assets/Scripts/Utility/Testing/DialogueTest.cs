using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    [SerializeField]
    private DialogueSet set;
    public void ShowDialogue()
    {
        DialogueManager.Instance.Show(set);
    }
}
