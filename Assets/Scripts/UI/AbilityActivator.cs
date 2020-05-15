using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityActivator : MonoBehaviour
{
    [SerializeField]
    CardDisplay display;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(!display.card.cardAbilityUsed)
        {
            display.card.BeginUseAbility();
        }
    }
}
