using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSingleton : MonoBehaviour
{
    public  PopUpMessages PopUpMessages;
    public static UiSingleton Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;        
    }

    public void ShowLeftMessage(string message)
    {
        PopUpMessages.AddToQueue(message);
    }

}


