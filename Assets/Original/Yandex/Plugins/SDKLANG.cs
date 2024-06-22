using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SDKLANG : SingletonBase<SDKLANG>
{
    public string Languages;
    public string deviceString;

    [DllImport("__Internal")] private static extern void ProjectStarted();
    
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
       ProjectStarted();
    }



    public void GettingLang(string lang)
    {
        print(lang);
        SetLang(lang);
    }

    private void SetLang(string _lang)
    {
        var json = JSON.Parse(_lang);
        string lang = json["browser"]["lang"];

        UIController.Instance.LocalizationData.LoadLocalizaionSDKText(lang);
    }

    public void GettingDevice(string _device)
    {
        var json = JSON.Parse(_device);
        string device = json["type"];
        print(device);
        deviceString = device;
    }
}
