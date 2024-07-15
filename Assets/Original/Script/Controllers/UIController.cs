using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : SingletonBase<UIController>
{
    [SerializeField] public LocalizationData LocalizationData;
    [SerializeField] private GameObject _firsStartPlaySettingsPanel;

    protected override void Awake()
    {
        base.Awake();
        LocalizationData.LoadLocalizaionText();
    }

    private void Start()
    {

    }

    public void FirstStartSettingsSetActive()
    {       
        _firsStartPlaySettingsPanel.SetActive(true);
    }
}
