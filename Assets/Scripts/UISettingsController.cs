using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsController : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown languageDropdown;
    public Toggle musicToggle;
    public Toggle windowToggle;

    private List<string> resolutions;


    private void Start()
    {

        GameSettings settings = SettingsManager.instance.currentSettings;
        resolutionDropdown.value = 1;

        musicToggle.isOn = settings.musicEnabled;

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        musicToggle.onValueChanged.AddListener(OnMusicChanged);

    }

    void OnResolutionChanged(int index)
    {
        
        SettingsManager.instance.currentSettings.screenHeight = ;
        SettingsManager.instance.currentSettings.screenWidth = ;
        //дописать сохраннение
    }

    void OnMusicChanged(bool state)
    {
        SettingsManager.instance.currentSettings.musicEnabled = state;
        //дописать сохраннение
    }


}
