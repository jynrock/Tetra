using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityActivator : MonoBehaviour
{
    [SerializeField]
    CardDisplay display;

    [SerializeField]
    MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(display.card != null && display.card.cardAbilityUsed)
        {
            rend.material.color = new Color(0.3f, 0.3f, 0.3f);
        }
    }

    void OnMouseDown()
    {
        if(!display.card.cardAbilityUsed)
        {
            rend.material.color = new Color(0.9f, 0.9f, 0.9f);
            display.card.BeginUseAbility();
        }
    }

    void OnMouseEnter()
    {
        if(!display.card.cardAbilityUsed)
        {
            rend.material.color = new Color(0.8f, 0.8f, 0.8f);
        }
    }

    void OnMouseExit()
    {
        if(!display.card.cardAbilityUsed)
        {
            rend.material.color = new Color(0.7f, 0.7f, 0.7f);
        }
    }
}
