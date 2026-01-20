using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
public class UICarEditorController : MonoBehaviour
{
    [SerializeField] private GameObject _detailsInventory;
    [SerializeField] private LevelEditor _levelEditor;

    private void OnEnable()
    {
        UIUpdate();
    }

    public void UIUpdate()
    {
        Clear();
        CarSettings carSettings = _levelEditor.currentLevel.carSettings;
        Transform transform = _detailsInventory.GetComponent<Transform>();

        if(carSettings.wheel == 1)
        {
            transform.Find("ItemWheel1").gameObject.SetActive(true);
            transform.Find("ItemWheel2").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("ItemSpikedWheel1").gameObject.SetActive(true);
            transform.Find("ItemSpikedWheel2").gameObject.SetActive(true);
        }

        if (carSettings.booster == 1) { 
            transform.Find("ItemRocket").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("ItemFan").gameObject.SetActive(true);
        }

        if (carSettings.wings)
        {
            transform.Find("ItemWings").gameObject.SetActive(true);
        }
    }

    public void Clear()
    {
        foreach(Transform item in _detailsInventory.GetComponentInChildren<Transform>())
        {
            item.gameObject.SetActive(false);
        }
    }
}