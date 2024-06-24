using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.ScrollRect;

public enum LanguageLocalization
{
    English,
    Russian,
    Turkish,
    German,
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

        if (SDKLANG.Instance.Languages != null)
        {
            Debug.Log("Languages = " + SDKLANG.Instance.Languages);
            return SDKLANG.Instance.Languages;

        }
        else
        {
            Debug.Log("Languages = null ");
            return LanguageLocalization.English.ToString();
        }


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
        Debug.Log("Локализация загружена");
    }
    public void ChangeLanguage()
    {


/*        if (language == LanguageLocalization.Russian)
        {
            
        }
        if (language == LanguageLocalization.Turkish)
        {
            
        }
        if (language == LanguageLocalization.German)
        {
            
        }
        if (language == LanguageLocalization.English)
        {
            
        }*/

        switch (language)
        {
            case LanguageLocalization.Russian:
                language = LanguageLocalization.Turkish;
                break;
            case LanguageLocalization.German:
                language = LanguageLocalization.English;
                break;
            case LanguageLocalization.Turkish:
                language = LanguageLocalization.German;
                break;
            case LanguageLocalization.English:
                language = LanguageLocalization.Russian;
                break;

        }

        Localization(language.ToString());

    }

    public void LoadLocalizaionSDKText(string Language)
    {
/*        if (Language == "ru")
        {
            Localization("Russian");
            language = LanguageLocalization.Russian;
        }
        if (Language == "en")
        {
            Localization("English");
            language = LanguageLocalization.English;
        }*/

        if (PlayerPrefs.GetInt("FirstStartLocalizaion", 0) == 0)
        {
            if (Language == "ru")
            {
                Localization("Russian");
                language = LanguageLocalization.Russian;
                PlayerPrefs.SetString("Language", language.ToString());
            }
            if (Language == "en")
            {
                Localization("English");
                language = LanguageLocalization.English;
                PlayerPrefs.SetString("Language", language.ToString());
            }
            if (Language == "tr")
            {
                Localization("Turkish");
                language = LanguageLocalization.Turkish;
                PlayerPrefs.SetString("Language", language.ToString());
            }
            if (Language == "de")
            {
                Localization("German");
                language = LanguageLocalization.German;
                PlayerPrefs.SetString("Language", language.ToString());
            }

            PlayerPrefs.SetInt("FirstStartLocalizaion", 1);
        }
        else
        {
            Localization(PlayerPrefs.GetString("Language", "English"));
        }

    }

}
