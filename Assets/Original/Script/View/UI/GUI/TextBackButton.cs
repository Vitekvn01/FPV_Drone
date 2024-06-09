using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBackButton : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationData.DictionaryLocalizationWords["Back"];
    }
}
