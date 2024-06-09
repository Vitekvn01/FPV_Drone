
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Prologue : MonoBehaviour
{
    [SerializeField] private bool playStart;

    [SerializeField] private GameObject panelPrlogue;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private List<string> stringTask_ID = new List<string>();

    [SerializeField] private Image Image;
    [SerializeField] private TextMeshProUGUI text;


    [SerializeField] private UnityEvent EndPrologue;

    private int index = 0;

    private void Start()
    {
        panelPrlogue.SetActive(false);

        if (playStart)
        {
            panelPrlogue.SetActive(true);
            DrawAndPlay();
        }
    }

    private void DrawAndPlay()
    {
        Time.timeScale = 0f;
        Image.sprite = sprites[index];
        text.text = LocalizationData.DictionaryLocalizationWords[stringTask_ID[index].ToString()];

    }
    public void NextPage()
    {
        index += 1;
        if (index < sprites.Count)
        {
            DrawAndPlay();
        }
        else
        {
            Time.timeScale = 1f;
            panelPrlogue.SetActive(false);
            EndPrologue.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void StartPrologue()
    {
        index = 0;
        panelPrlogue.SetActive(true);
        DrawAndPlay();
    }
}
