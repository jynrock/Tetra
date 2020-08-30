using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour
{
    private Quaternion targetQuat;

    private Quaternion neutral = Quaternion.Euler(new Vector3(62.333f, 0, 0));
    private Quaternion upQuat = Quaternion.Euler(new Vector3(0, 0, 0));
    private Quaternion downQuat = Quaternion.Euler(new Vector3(75, 0, 0));
    private Quaternion rightQuat = Quaternion.Euler(new Vector3(0, 50, 0));
    private Quaternion leftQuat = Quaternion.Euler(new Vector3(0, -50, 0));

    private Coroutine activeCoroutine;

    private bool dragging;

    [SerializeField]
    public BoolGameEvent disableControlsEvent;

    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        targetQuat = neutral;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            dragging = true;
            disableControlsEvent.Raise(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(Input.GetMouseButtonUp(1))
        {
            dragging = false;
            disableControlsEvent.Raise(false);
            Cursor.lockState = CursorLockMode.None;
            targetQuat = transform.rotation;
            MoveCamera(neutral);
        }
        if(dragging)
        {
            transform.Rotate(-Input.GetAxis("Mouse Y") * 10, Input.GetAxis("Mouse X") * 10, 0);
            float z = transform.eulerAngles.z;
            transform.Rotate(0, 0, -z);
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            MoveCamera(upQuat);
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            MoveCamera(downQuat);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            MoveCamera(rightQuat);
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            MoveCamera(leftQuat);
        }
        if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            MoveCamera(neutral);
        }
    } 

    public void MoveCamera(Quaternion destinationQuat) {
        if(targetQuat != destinationQuat) {
            Quaternion sourceQuat = transform.rotation;
            if(activeCoroutine != null){
                StopCoroutine(activeCoroutine);
            }
            targetQuat = destinationQuat;
            activeCoroutine = StartCoroutine(MoveCameraCorountine(sourceQuat, destinationQuat));
        }
    }

    private IEnumerator MoveCameraCorountine(Quaternion source, Quaternion dest) {
        float time = 0.0f;
        while (time < 0.1f) {
            transform.rotation = Quaternion.Slerp(source, dest, time / 0.1f);
            time = time + Time.deltaTime;
            yield return null;
        }
        transform.rotation = dest;
    }
}
