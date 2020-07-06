using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName="Dialogue/Dialogue Set")]
public class DialogueSet : ScriptableObject
{
    public List<DialogueNode> dialogueNodes;
}
