using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDatabase : MonoBehaviour
{
    [SerializeField]
    private List<string> levels;

    public List<string> GetLevelNames()
    {
        return levels;
    }
}