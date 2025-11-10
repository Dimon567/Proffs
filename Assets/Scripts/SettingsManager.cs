using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingsManager : MonoBehaviour
{
    private string settingsPath;
    public static SettingsManager instance;
    public GameSettings currentSettings;
    

    void Awake()
    {
        instance = this;
        settingsPath = Path.Combine(Application.persistentDataPath, "setting.json");

        LoadSettings();
    }

    public void LoadSettings()
    {
        if (File.Exists(settingsPath)){
            string json = File.ReadAllText(settingsPath);
            currentSettings = JsonUtility.FromJson<GameSettings>(json);
            Debug.Log($"Настройки загружены {json}");
            return;
        }

        currentSettings = new GameSettings();
        Debug.Log($"Файл настроик ненайден");
    }

    public void SaveSettings()
    {
        string json = JsonUtility.ToJson(currentSettings, true);
        File.WriteAllText(settingsPath, json);
        Debug.Log($"Настройки сохранены: {json}");
    }
}

[Serializable]
public class GameSettings
{
    public int screenWidth = 1920;
    public int screenHeight = 1080;
    public bool windowsMode = false;
    public bool musicEnabled = true;
    public string language = "English";
}
