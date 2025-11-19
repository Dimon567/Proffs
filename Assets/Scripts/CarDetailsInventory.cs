using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
public class CarDetailsInventoryController : MonoBehaviour
{
    [SerializeField] List<PrefabAssetType> allPrefabs = new List<PrefabAssetType>();

    List<int> inventoryItems = new List<int>();
    CarDetailsInventoryController instance;
    void Awake()
    {
        instance = this;
    }
}
[Serializable]
public class CarDetail
{

}