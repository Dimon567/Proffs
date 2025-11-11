using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsController : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown languageDropdown;
    public Toggle musicToggle;
    public Toggle windowToggle;
    public Button saveButton;
    public Button rollbackSettingsButton;

    private Dictionary<string, Vector2Int> resolutions = new Dictionary<string, Vector2Int>{
        {"1280:720", new Vector2Int(1280, 720)},
        {"1366:768", new Vector2Int(1366, 768)},
        {"1600:900", new Vector2Int(1600, 900)},
        {"1920:1080", new Vector2Int(1920, 1080)}
    };

    private List <string> languages = new List<string>{
        "English",
        "Русский"
    };

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutions.Keys.ToList<string>());

        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(languages);

        UpdateUI();

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
        musicToggle.onValueChanged.AddListener(OnMusicChanged);
        windowToggle.onValueChanged.AddListener(OnWindowsModeChanged);
        saveButton.onClick.AddListener(SaveSettings);
        rollbackSettingsButton.onClick.AddListener(RollBackSettings);

    }

    void UpdateUI()
    {
        GameSettings settings = SettingsManager.instance.currentSettings;

        resolutionDropdown.value = resolutions.Keys.ToList().IndexOf(settings.screenSize);

        languageDropdown.value = languages.IndexOf(settings.language);

        musicToggle.isOn = settings.musicEnabled;

        windowToggle.isOn = settings.windowsMode;
    }

    void SaveSettings()
    {
        SettingsManager.instance.SaveSettings();
    }

    void RollBackSettings()
    {
        SettingsManager.instance.LoadSettings();
        UpdateUI();
    }

    void OnResolutionChanged(int index)
    {
        SettingsManager.instance.currentSettings.screenSize = resolutions.Keys.ToList()[index];
    }

    void OnMusicChanged(bool state)
    {
        SettingsManager.instance.currentSettings.musicEnabled = state;
    }

    void OnLanguageChanged(int index) {
        SettingsManager.instance.currentSettings.screenSize = languages[index];
    }

    void OnWindowsModeChanged(bool state)
    {
        SettingsManager.instance.currentSettings.windowsMode = state;
    }


}
