using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton Instance { get; private set; }
    public Inventory inventory { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        inventory = new Inventory();
    }
}


public class Inventory { 

    public List<Mineral> Minerals { get; set; }
    public Inventory()
    {
        this.Minerals = new List<Mineral>();
        
    }


    public void RegisterMineral(Mineral mineral) {

        if (this.Minerals.FirstOrDefault(x => x.Data.Type == mineral.Data.Type) == null) { 
            this.Minerals.Add(mineral);
        }

    }
    public void MineralIncrementCount(MineralTypes mineral, int incrementAmount, bool showAddNotification) {
        
        var mineralInmemory = this.Minerals.FirstOrDefault(x => x.Data.Type == mineral);
        mineralInmemory.ActualAmmount += incrementAmount;

        if (showAddNotification) {
            UiSingleton.Instance.ShowLeftMessage($"+{incrementAmount} {mineral.ToString()} ({mineralInmemory.ActualAmmount})"); 
        }

        //! #Dev
        Debug.Log($"Added {incrementAmount} {mineralInmemory.ToString()} :" +
                  $" {mineralInmemory.ActualAmmount}");
    }

}
