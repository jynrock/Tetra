using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI speakerNameText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Image speakerIcon;
    [SerializeField]
    private GameObject coverer;
    [SerializeField]
    private RectTransform textRect;

    private DialogueSet currentSet;
    private int currentIndex;

    private Vector2 defaultAnchorMin = new Vector2(.2f, .15f);
    private Vector2 defaultAnchorMax = new Vector2(.985f, .75f);

    public void Setup(DialogueSet dialogueSet)
    {
        currentSet = dialogueSet;
        currentIndex = -1;
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        AudioManager.Instance.StopCurrentDialogue();
        currentIndex++;
        if(currentIndex < currentSet.dialogueNodes.Count)
        {
            DisplayText(currentSet.dialogueNodes[currentIndex]);
        }
        else
        {
            Destroy(coverer);
        }
    }

    private void ResetText()
    {
        speakerNameText.text = "";
        dialogueText.text = "";
        speakerIcon.sprite = null;
        textRect.anchorMin = defaultAnchorMin;
        textRect.anchorMax = defaultAnchorMax;
    }

    private void DisplayText(DialogueNode node)
    {
        AudioClip localClip = node.LocalizedAudioClip();

        if(node.isNarration)
        {
            textRect.anchorMin = new Vector2(0.015f, 0.15f);
            textRect.anchorMax = new Vector2(0.985f, 0.95f);
        }
        else
        {
            textRect.anchorMin = defaultAnchorMin;
            textRect.anchorMax = defaultAnchorMax;
        }

        speakerNameText.text = node.LocalizedName() ?? "";
        dialogueText.text = node.LocalizedText() ?? "";
        if(node.icon != null)
        {
            speakerIcon.sprite = node.icon;
        }
        else
        {
            speakerIcon.color = new Color(0,0,0,0);
        }
        if(localClip != null)
        {
            AudioManager.Instance.PlayDialogue(localClip);
        }
    }
}
