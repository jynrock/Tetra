using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHandDisplay : MonoBehaviour
{
    public Player owner;

    [SerializeField]
    private TextMeshPro nameText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = owner.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
