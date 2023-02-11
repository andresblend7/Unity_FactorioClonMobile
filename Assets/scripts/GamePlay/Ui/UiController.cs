using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiController : MonoBehaviour, IPointerClickHandler
{

    public Camera camera;

    public void OnPointerClick(PointerEventData eventData)
    {
        var pointerClickName = eventData.pointerCurrentRaycast.gameObject.name;
        Debug.Log("Pointer Enter" + pointerClickName);

        switch (pointerClickName)
        {

            case "zoom+":
                camera.orthographicSize += 0.5f;
                break;

            case "zoom-":
                camera.orthographicSize -= 0.5f;

                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
