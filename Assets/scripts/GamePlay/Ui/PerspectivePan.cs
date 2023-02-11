using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePan : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 2)] private float speed;

    private Vector3 panStart;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {

        if (Input.touchCount == 1)
        {

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                panStart = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = panStart - cam.ScreenToWorldPoint(touch.position);
                direction.y = 0;
                cam.transform.position += direction * speed;
            }
        }
    }


}
