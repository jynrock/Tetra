using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Card card;
    
    [SerializeField]
    private GameObject cardHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTryPlayCardSucceeded(CardTileEventData data)
    {
        if(data.tile == this)
        {
            card = data.card;
            card.transform.SetParent(cardHolder.transform);
            card.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
