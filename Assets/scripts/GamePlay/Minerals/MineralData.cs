using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralData : MonoBehaviour
{
    public string Name;
    public string Item;
    public float timeToPlayerMine = 0.2f;
   [HideInInspector] public MineralTypes Type;
}

public interface IMineral {

    void PlayerClick();
    void RegisterMineral();

    IEnumerator TimerEnableMining();



}
