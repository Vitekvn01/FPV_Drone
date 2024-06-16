using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu]
public class LevelProperties : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private string _sceneName;
    [SerializeField] private Sprite _previewImage;
    [SerializeField] private bool _levelLock;
    [SerializeField] private string _nextSceneName;
    [SerializeField] private LevelProperties _nextLevelProperties;

    public string Title => _title;
    public string SceneName => _sceneName;
    public string NextSceneName => _nextSceneName;
    public Sprite PreviewImage => _previewImage;
    public bool LevelLock => _levelLock;

    public LevelProperties NextLevelProperties => _nextLevelProperties;

    public void SetLevelUnlock()
    {
        if (LevelLock)
        {
            Debug.Log("SetLevelUnlock " + _title);
            _levelLock = false;
        }
        
    }




}


