using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemController : MonoBehaviour
{

    
    private int gridWidth = 36;
    private int gridHeight = 36;
    private int cellSize = 1;
    public GameObject cameraPivot;

    public Transform[] sceneryMinerals;


    private List<CellInfo> grid;

    public GameObject CellPH_allowBuild;

    public List<CellCordinates> CellsNotAllowed;


    private void Awake()
    {
        this.CellsNotAllowed = new List<CellCordinates>();
        this.grid = new List<CellInfo>();
        this.RegisterSceneryCells();
    }

    private void RegisterSceneryCells()
    {
        foreach (var mineralCoords in sceneryMinerals)
        {
            var mineral = mineralCoords.position;

            //Debug.Log(mineral.x+" <--> "+mineral.z);

            this.CellsNotAllowed.Add(new CellCordinates { 
                x = (int) mineral.x,
                z = (int) mineral.z
            });
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initGrid();       
    }

    void ShowAndUpdateGrid() {
        foreach (var cell in grid)
        {

            bool canSetObject = true;
            //Debug.Log("z=>" + z);
            foreach (var notAllowed in CellsNotAllowed)
            {
                //Debug.Log("searching"+ cell.Coords.x+"  ___ notAllowed->" + notAllowed.x);

                if (notAllowed.x == cell.Coords.x && notAllowed.z == cell.Coords.z)
                {
                    canSetObject = false;
                    break;
                }
            }

            if (canSetObject)
            {
                cell.Cell.SetActive(true);
            }
            else {
                cell.Cell.SetActive(false);
            }
        }
    }


    void initGrid() {

        var xPosCamera = (int) cameraPivot.transform.position.x;
        var zPosCamera = (int) cameraPivot.transform.position.z;

        //Debug.Log("x=" + (xPosCamera ) + " - " + (zPosCamera ));

        var xFirstPos = xPosCamera - 14;
        var zFirstPos = zPosCamera - 14;

        for (int x = 0; x < gridWidth; x++)
        {
            var coordX = (x + xFirstPos);

            for (int z = 0; z < gridHeight; z++)
            {
                var coordZ = (z + zFirstPos);
                GameObject cell = Instantiate(CellPH_allowBuild, new Vector3(coordX, 0.52f, coordZ), Quaternion.identity);
                cell.transform.parent = transform;

                grid.Add(new CellInfo()
                {
                    Cell = cell,
                    Coords = new CellCordinates{ 
                        x = coordX,
                        z = coordZ
                    }
                });

            }
        }

        //ShowAndUpdateGrid();
    }

    private void hideGrid()
    {
        foreach (var cell in grid)
            cell.Cell.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            ShowAndUpdateGrid();
        }

        if (Input.GetKeyDown("up")) {
            hideGrid();
        }
    }

   
}

public class CellCordinates {
    public int x { get; set; }
    public int z { get; set; }
}

public class CellInfo {
    public GameObject Cell { get; set; }
    public CellCordinates Coords { get; set; }

}