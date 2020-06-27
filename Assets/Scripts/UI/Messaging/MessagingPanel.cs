using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessagingPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI messageType;
    [SerializeField]
    private TextMeshProUGUI messageTitle;
    [SerializeField]
    private TextMeshProUGUI messageText;
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    private GameObject coverer;

    public void Setup(MessageType type, string title, string text, Messaging.CallbackFunction callbackFunction)
    {
        SetText(type, title, text);
        AddCloseBehaviour(callbackFunction ?? DefaultCloseBehaviour);
    }

    private void ResetText()
    {
        messageType.text = "";
        messageTitle.text = "";
        messageText.text = "";
        closeButton.onClick.RemoveAllListeners();
    }

    private void SetText(MessageType type, string title, string text)
    {
        messageType.text = type.ToString();
        messageType.color = Messaging.GetTypeColor(type);
        messageTitle.text = title;
        messageText.text = text;
    }

    private void AddCloseBehaviour(Messaging.CallbackFunction callback)
    {
        closeButton.onClick.AddListener(() => callback());
    }

    private void DefaultCloseBehaviour()
    {
        Destroy(coverer);
    }
}
