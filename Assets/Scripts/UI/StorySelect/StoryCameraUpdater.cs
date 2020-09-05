using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCameraUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCameraPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPiece.transform.position.z-9);
    }
}
