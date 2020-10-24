using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class TitleScreenLoader : MonoBehaviour
{
    [SerializeField]
    private BoolGameEvent sceneLoadedEvent;

    [SerializeField]
    private GameObject preloaderObject;

    void Start()
    {
        StartCoroutine(LoadTitle());
    }

    private IEnumerator LoadTitle()
    {
        yield return null;
        var test = LocalizationSettings.Instance.GetInitializationOperation();
        while(!test.IsDone)
        {
            yield return null;
        }
        Destroy(preloaderObject);
        sceneLoadedEvent.Raise(true);
    }
}
