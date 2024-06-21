using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ScrollRect;

public enum LanguageLocalization
{
    English,
    Russian,
}

[CreateAssetMenu]
public class LocalizationData : ScriptableObject
{
    public LanguageLocalization language;
    public LanguageLocalization Language => language;


    public static Dictionary<string, string> DictionaryLocalizationWords = new Dictionary<string, string>();

    private string GetSystemLanguage()
    {
/*        if (Enum.IsDefined(typeof(LanguageLocalization), Application.systemLanguage.ToString()))
        {
            Debug.Log(Application.systemLanguage.ToString());
            return Application.systemLanguage.ToString();
        }
        else
        {
            return SystemLanguage.English.ToString();
        }*/

        return SDKLANG.Instance.Languages;

    }
    private string GetLocalizationText(string NameLocalizationFile)
    {
        Debug.Log(NameLocalizationFile);
        language = (LanguageLocalization)Enum.Parse(typeof(LanguageLocalization), NameLocalizationFile);
        return Resources.Load($"Localization/{NameLocalizationFile}").ToString();
    }
    private void ParseAllText(string Text)
    {
        List<string> words = new List<string>(Text.Split('\n'));
        foreach (string word in words)
        {
            string[] text = word.Split(" : ");
/*            Debug.Log(text[0] + " = " + text[1]);*/
            DictionaryLocalizationWords.Add(text[0], text[1]);
        }
    }

    public void LoadLocalizaionText()
    {
        if (PlayerPrefs.GetInt("FirstStartLocalizaion", 0) == 0)
        {
            Localization(GetSystemLanguage());
            PlayerPrefs.SetString("Language", GetSystemLanguage());
            PlayerPrefs.SetInt("FirstStartLocalizaion", 1);
        }
        else
        {
            Localization(PlayerPrefs.GetString("Language", GetSystemLanguage()));
        }
    }

    private void Localization(string Language)
    {
        DictionaryLocalizationWords.Clear();
        string allText = GetLocalizationText(Language);
        PlayerPrefs.SetString("Language", Language);
        ParseAllText(allText);
    }
    public void ChangeLanguage()
    {
        if (language == LanguageLocalization.English)
        {
            language = LanguageLocalization.Russian;
        }
        else
        {
            language = LanguageLocalization.English;
        }

        Localization(language.ToString());

    }

}
