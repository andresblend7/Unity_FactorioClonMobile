using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DevHelper : MonoBehaviour
{
    public TMP_Text txtDev;
    public float deltaTime;
    public int targetFrameRate = 60;

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        txtDev.text = Mathf.Ceil(fps).ToString();

    }


    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}
