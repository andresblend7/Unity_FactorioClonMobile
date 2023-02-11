using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour, IMineral
{
    private MineralData mineralData;
    public void PlayerClick()
    {
        PlayerSingleton.Instance.inventory.MineralIncrementCount(mineralData.Type, 1);
    }

    public void RegisterMineral()
    {
        this.mineralData = GetComponent<MineralData>();
        this.mineralData.Type = MineralTypes.Rock;
        PlayerSingleton.Instance.inventory.RegisterMineral(new Mineral
        {
            ActualAmmount = 0,
            Data = mineralData
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        this.RegisterMineral();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
