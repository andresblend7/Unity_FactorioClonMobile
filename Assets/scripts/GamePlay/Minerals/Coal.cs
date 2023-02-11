using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour, IMineral
{
    private MineralData mineralData;
    bool mining = false;
    public void PlayerClick()
    {
        if (!mining)
        {
            this.mining = true;
            PlayerSingleton.Instance.inventory.MineralIncrementCount(mineralData.Type, 1, true);
            StartCoroutine(TimerEnableMining());
        }
    }

    public IEnumerator TimerEnableMining()
    {
        yield return new WaitForSeconds(this.mineralData.timeToPlayerMine);
        this.mining = false;
    }

    public void RegisterMineral()
    {
        this.mineralData = GetComponent<MineralData>();
        this.mineralData.Type = MineralTypes.Coal;
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
