using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeDatabase : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> themePrefabs;

    public GameObject GetThemePrefab(Theme theme)
    {
        GameObject themePrefab = null;

        switch(theme){
            case Theme.Tavern:
                themePrefab = themePrefabs[0];
                break;
            default:
                break;
        }

        return themePrefab;
    }
}
