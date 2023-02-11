using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralGeneral
{
  
}

public enum MineralTypes { 
    Rock = 1,
    Coal
}

public class Mineral {
    public MineralData Data { get; set; }
    public int ActualAmmount { get; set; }

}

