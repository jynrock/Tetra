using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenLoader : MonoBehaviour
{
    [SerializeField]
    private BoolGameEvent sceneLoadedEvent;

    [SerializeField]
    private GameObject[] preloaderObjects;

    void Start()
    {
        StartCoroutine(LoadTitle());
    }

    private IEnumerator LoadTitle()
    {
        yield return null;
        foreach(GameObject go in preloaderObjects)
        {
            Destroy(go);
        }
        yield return new WaitForSeconds(1.0f);
        sceneLoadedEvent.Raise(true);
    }
}
