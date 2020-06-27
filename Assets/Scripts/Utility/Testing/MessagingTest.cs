using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingTest : MonoBehaviour
{
    public void ShowError()
    {
        Messaging.Instance.Show(MessageType.Error, "Test Error", "Please do not be alarmed, this is a test error. No further input is required. Please press 'Close' to continue playing the game. Thank you. I love you.");
    }

    public void ShowInfo()
    {
        Messaging.Instance.Show(MessageType.Info, "Test Info", "This is test information. No further intervention is required from you, the player. Thank you and good luck. I love you.");
    }

    public void ShowErrorWithAltBehaviour()
    {
        Messaging.Instance.Show(MessageType.Error, "Test Error With Alt Behaviour", "This test error will not close the window. Sorry, you're stuck here forever now, please restart the game.", () => {Messaging.Instance.Show(MessageType.Info, "Test Info", "This test information is just an attempt to prove that we can handle having multiple messages displayed at once. Hooray!");});
    }
}
