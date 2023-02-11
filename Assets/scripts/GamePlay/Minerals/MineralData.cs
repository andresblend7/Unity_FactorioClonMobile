using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralData : MonoBehaviour
{
    public string Name;
    public string Item;
   [HideInInspector] public MineralTypes Type;
}

public interface IMineral {

    void PlayerClick();
    void RegisterMineral();

}
