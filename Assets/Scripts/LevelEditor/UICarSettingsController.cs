using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class CarSettingsUIController : MonoBehaviour
{
    [SerializeField] private LevelEditor _levelEditor;
    [SerializeField] private Toggle _bananaToggle;
    [SerializeField] private Toggle _milkToggle;
    [SerializeField] private Toggle _canToggle;
    [SerializeField] private Toggle _spikenWheelToggle;
    [SerializeField] private Toggle _rocketToggle;
    [SerializeField] private Toggle _fanToggle;
    [SerializeField] private Toggle _wingsToggle;

    private void Start()
    {
        _bananaToggle.onValueChanged.AddListener(SelectBanana);
        _milkToggle.onValueChanged.AddListener(SelectMilk);
        _canToggle.onValueChanged.AddListener(SelectCan);
        _spikenWheelToggle.onValueChanged.AddListener(SelectSpikenWheel);
        _rocketToggle.onValueChanged.AddListener(SelectRocket);
        _fanToggle.onValueChanged.AddListener(SelectFan);
        _wingsToggle.onValueChanged.AddListener(SelectWings);
    }

    public void SelectBanana(bool value)
    {
        if (!value) return;
        _levelEditor.currentLevel.carSettings.body = 1;
    }
    public void SelectMilk(bool value)
    {
        if (!value) return;
        _levelEditor.currentLevel.carSettings.body = 2;
    }
    public void SelectCan(bool value)
    {
        if (!value) return;
        _levelEditor.currentLevel.carSettings.body = 3;
    }

    public void SelectSpikenWheel(bool value)
    {
        if (value)
        {
            _levelEditor.currentLevel.carSettings.wheel = 1;
        }
        else
        {
            _levelEditor.currentLevel.carSettings.wheel = 2;
        }
    }

    public void SelectRocket(bool value)
    {
        if (!value) return;
        _levelEditor.currentLevel.carSettings.booster = 0;
    }
    public void SelectFan(bool value)
    {
        if (!value) return;
        _levelEditor.currentLevel.carSettings.booster = 1;
    }

    public void SelectWings(bool value)
    {
        _levelEditor.currentLevel.carSettings.wings = value;
    }

}
