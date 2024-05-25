using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class LevelProperties : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private string _sceneName;
    [SerializeField] private Sprite _previewImage;
    [SerializeField] private bool _levelLock;

    public string Title => _title;
    public string SceneName => _sceneName;
    public Sprite PreviewImage => _previewImage;
    public bool LevelLock => _levelLock;

    public void SetLevelUnlock()
    {
        if (LevelLock)
        {
            _levelLock = false;
        }
        
    }




}


