using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    private InstantiateObjectsController instantiateObjectsController;

    bool touched = false;

    // Start is called before the first frame update
    void Start()
    {
        this.instantiateObjectsController = GameObject.FindObjectOfType<InstantiateObjectsController>();
    }

    // Update is called once per frame
    void Update()
    {
       
       

    }


}
