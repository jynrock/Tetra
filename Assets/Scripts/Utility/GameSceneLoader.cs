using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneLoader : MonoBehaviour
{
    [SerializeField]
    private BoolGameEvent gameSceneLoadedEvent;
    [SerializeField]
    private GameObject standardLevelObjects;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGameScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadGameScene()
    {
        yield return null;
        // load logic goes here
        GameObject themeDressing = Database.Instance.Theme.GetThemePrefab(LevelManager.Instance.theme);
        Instantiate(themeDressing);
        standardLevelObjects.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gameSceneLoadedEvent.Raise(true);
        Destroy(gameObject);
    }
}
