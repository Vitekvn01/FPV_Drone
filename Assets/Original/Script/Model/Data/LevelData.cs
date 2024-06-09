using System;
using System.IO;
using UnityEngine;


[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    const string filename = "LevelProgress.dat";

    private static LevelProperties _currentLevel;

    public static LevelProperties CurrentLevel => _currentLevel;

    [SerializeField] private LevelProperties[] _levels;

    [SerializeField] private int _countLevelUnlock;

    public LevelProperties[] Levels => _levels;

    public int LastUnlockLevel => _countLevelUnlock;

    public static void SetCurrentLevel(LevelProperties level)
    {
        _currentLevel = level;
    }

    public void NextLevelUnlock()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            Debug.Log(_levels[i] + " " + _currentLevel);
            if (_levels[i] == _currentLevel)
            {
                if (_levels[i + 1].LevelLock)
                {
                    _levels[i + 1].SetLevelUnlock();
                    _countLevelUnlock += 1;
                    SaveToFile();
                }
            }
        }

    }

    public void LoadLevelsUnlock()
    {
        LoadFromFile(this);
        for (int i = 0; i == _countLevelUnlock; i++)
        {
            if (_countLevelUnlock < _levels.Length)
            {
                _levels[i].SetLevelUnlock();
            }
        }
    }

    [System.Serializable]
    public class LevelDataContainer
    {
        public int CountLevelUnlock;

    }

    public void SaveToFile()
    {
  
        Debug.Log("Save");
        string filePath = Path.Combine(Application.persistentDataPath, filename);/// 1. Получение пути к файлу:

        // Создаем экземпляр LevelDataContainer и сохраняем в него массив _levels
        LevelDataContainer container = new LevelDataContainer
        {
            CountLevelUnlock = _countLevelUnlock
        };

        // Преобразуем экземпляр LevelDataContainer в JSON-строку и сохраняем в файл
        var data = JsonUtility.ToJson(container); /// JsonUtility.ToJson(this) преобразует экземпляр LevelData в JSON-строку.
        File.WriteAllText(filePath, data);/// Запись данных в файл:
    }

    public static LevelData LoadFromFile(LevelData existingLevelData)
    {
        Debug.Log("Load");
        string filePath = Path.Combine(Application.persistentDataPath, filename);
    
        if (File.Exists(filePath))
        {
            var data = File.ReadAllText(filePath);
    
            // Десериализуем данные из файла в экземпляр LevelDataContainer
            LevelDataContainer container = JsonUtility.FromJson<LevelDataContainer>(data);
    
            // Записываем данные из контейнера в существующий экземпляр LevelData
            existingLevelData._countLevelUnlock = container.CountLevelUnlock;
    
            return existingLevelData;
        }
        else return null;
    }
}

