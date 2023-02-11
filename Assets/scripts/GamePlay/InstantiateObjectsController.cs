using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectsController : MonoBehaviour
{
    //! Entidades, items, Objetos

    public GameObject[] Objects;

    public void InstanteObjectInCell(int indexObject, int x, int z) {

        Instantiate(Objects[indexObject],  new Vector3(x, 1, z), Quaternion.identity);
    
    }

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
               
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {

                        var objectHited = hit.transform.gameObject;
                        //Debug.Log("rayo "+ objectHited.tag);

                        if (objectHited.tag =="cell")
                        {
                         Debug.Log("Picó en una cell");
                        this.InstanteObjectInCell(0, (int)objectHited.transform.position.x, (int)objectHited.transform.position.z);
                             hit.transform.gameObject.SetActive(false);
                        }

                        //touched = true;
                        //Debug.Log("ME TOCO" + this.transform.position.x + " - " + transform.position.z);
                        //this.instantiateObjectsController.InstanteObjectInCell(0, 5, 5);
                    }

                
            }
        }
    }

}

