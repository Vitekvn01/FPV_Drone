using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : SingletonBase<UIController>
{
    [SerializeField] private LocalizationData _localizationData;
    [SerializeField] private GameObject _firsStartPlaySettingsPanel;

    protected override void Awake()
    {
        base.Awake();
        _localizationData.LoadLocalizaionText();
    }

    public void FirstStartSettingsSetActive()
    {       
        _firsStartPlaySettingsPanel.SetActive(true);
    }
}
