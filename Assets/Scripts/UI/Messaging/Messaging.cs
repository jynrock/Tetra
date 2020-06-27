using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Messaging : MonoBehaviour
{
    #region Singleton
    private static Messaging _instance;
    public static Messaging Instance { get {return _instance;} }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField]
    private MessagingPanel panelPrefab;

    public delegate void CallbackFunction();

    public void Show(MessageType type, string title, string text, CallbackFunction callback = null){
        MessagingPanel panelInst = Instantiate(panelPrefab);
        panelInst.transform.SetParent(transform, false);
        panelInst.Setup(type, title, text, callback);
    }

    public static Color GetTypeColor(MessageType type)
    {
        switch(type)
        {
            case MessageType.Error:
                return new Color(1, .27f, .27f, 1);
            case MessageType.Info:
                return new Color(1, 1, .3f, 1);
            default:
                return new Color(1, 1, 1, 1);
        }
    }

}
public enum MessageType {
    Error,
    Info
}