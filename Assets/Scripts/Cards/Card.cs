using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public StringProperty Name;
    public StringProperty Description;
    public IntProperty Health;
    public int Type;
    public IntProperty Attack;
    public IntProperty Defense;
    public MeshRenderer cardFront;
    public MeshRenderer cardBack;
    public CardArrows arrows;

    private Vector3 offset;
    private Vector3 screenPoint;
    private Vector3 originPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // MOUSE CONTROLS
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset =  transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 250);
        if(hit.collider != null)
        {
            Tile targetTile = hit.collider.gameObject.GetComponent<Tile>();
            if (targetTile != null)
            {
                targetTile.PlayCard(this);
            }
        }
    }

    void OnMouseEnter()
    {
        if(true)
        {
            Vector3 newPos = transform.position;
            newPos.z -= 0.1f;
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    void OnMouseExit()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
