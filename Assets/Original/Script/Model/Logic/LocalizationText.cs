using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationText : MonoBehaviour
{
    [SerializeField] private string _key;
    private TextMeshProUGUI _text;
    void Start()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        _text.text = LocalizationData.DictionaryLocalizationWords[_key];
    }
}
