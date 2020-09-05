using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySelectNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPiece;
    [SerializeField]
    private List<GameObject> storyNode;
    [SerializeField]
    private StoryCameraUpdater cameraUpdater;
    private int storyNodeIndex;

    void Start()
    {
        storyNodeIndex = 0;
    }
    
    public void MoveToNextNode()
    {
        if(storyNodeIndex < storyNode.Count - 1)
        {
            storyNodeIndex++;
            StartCoroutine(MovePlayer(storyNode[storyNodeIndex].transform.position));
        }
    }

    public void MoveToPreviousNode()
    {
        if(storyNodeIndex > 0)
        {
            storyNodeIndex--;
            StartCoroutine(MovePlayer(storyNode[storyNodeIndex].transform.position));
        }
    }

    public IEnumerator MovePlayer(Vector3 destination)
    {
        Vector3 startPos = playerPiece.transform.position;
        Vector3 endPos = new Vector3(destination.x, startPos.y, destination.z);
        float totalTime = 0.5f;
        float time = 0.0f;
        float fracComplete = 0.0f;
        while(time < totalTime)
        {
            time = time + Time.deltaTime;
            fracComplete = time / totalTime;
            playerPiece.transform.position = Vector3.Lerp(startPos, endPos, fracComplete);
            cameraUpdater.UpdateCameraPosition();
            yield return null;
        }
        playerPiece.transform.position = endPos;
    }
}
