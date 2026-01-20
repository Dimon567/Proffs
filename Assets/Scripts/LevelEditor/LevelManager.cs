using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instanse;
    public Levels levelsList;
    string path;

    void Awake()
    {
        instanse = this;
        path = Path.Combine(Application.persistentDataPath, "Levels.json");
        LoadLevels();
    }

    public void LoadLevels()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            levelsList = JsonUtility.FromJson<Levels>(json);
            return;
        }

        levelsList = new Levels();
    }

    public void SaveLevels()
    {
        string json = JsonUtility.ToJson(levelsList, true);
        File.WriteAllText(path, json);
        Debug.Log($"Save levels: {json}");
    }
    
}

[Serializable]
public class CarSettings
{
    public int body = 0;
    public int booster = 0;
    public int wheel = 0;
    public bool wings = false;
}

[Serializable]
public class ItemTransform
{
    public Vector3 position;
    public Vector3 rotation;
    public int id;

    public ItemTransform(Transform item)
    {
        position = item.position;
        rotation = item.eulerAngles;
        id = item.GetComponent<PrefabeLevelItemController>().prefabId;
    }
}

[Serializable]
public class Level
{
    public List<ItemTransform> items = new List<ItemTransform>();
    public CarSettings carSettings = new CarSettings();

    public void AddItem(Transform item)
    {
        ItemTransform itemTransform = new ItemTransform(item);
        items.Add(itemTransform);
        Debug.Log($"{items[0].rotation.x}");
    }
}

[Serializable]
public class Levels
{
    public List <Level> levels = new List<Level>();
}