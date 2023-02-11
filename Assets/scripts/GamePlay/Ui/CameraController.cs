using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;

    private Vector3 target;
    private bool isPanning;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                target = transform.position;
                isPanning = true;
            }
            else if (touch.phase == TouchPhase.Moved && isPanning)
            {
                Vector3 newPosition = transform.position;
                newPosition.x -= touch.deltaPosition.x * panSpeed * Time.deltaTime;
                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
                newPosition.z += touch.deltaPosition.y * panSpeed * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

                target = newPosition;
                transform.position = Vector3.Lerp(transform.position, target, panSpeed * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isPanning = false;
            }
        }
    
}

}
