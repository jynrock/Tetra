using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private static SettingsManager _instance;
    public static SettingsManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    [SerializeField]
    private AudioSource dialogueSource;

    void Awake()
    {
        if (_instance == null || _instance != this)
        {
            _instance = this;
        }
    }
}
