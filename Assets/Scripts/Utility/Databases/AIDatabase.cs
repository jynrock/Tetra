using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AIDatabase : MonoBehaviour
{
    public List<AIData> aI;

    public List<AIData> GetAll()
    {
        return aI;
    }

    public AIData GetAI(string name)
    {
        AIData selected = aI.Where(a => a.aIName == name).Single();
        selected.aIBaseType = GetAIBase(selected);
        return selected;
    }

    public AIData GetAI(int id)
    {
        AIData selected = aI[id];
        selected.aIBaseType = GetAIBase(selected);
        return selected;
    }

    private Type GetAIBase(AIData selected)
    {
        switch(selected.aIDifficulty)
        {
            case Difficulty.Chaotic:
                return typeof(RandoAI);
            default:
                return null;
        }
    }
}
