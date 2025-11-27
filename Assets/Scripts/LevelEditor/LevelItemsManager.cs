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
    public List<StepEdit> editSteps;
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
        }
    }

    public void SaveLevels()
    {
        string json = JsonUtility.ToJson(path, true);
        File.WriteAllText(path, json);
    }
    
}

[Serializable]
public class ItemTransform
{
    public Vector3 position;
    public Vector3 rotation;
    public int id;

    public ItemTransform (GameObject item)
    {
        position = item.transform.position;
        rotation = item.transform.eulerAngles;
        id = item.GetComponent<PrefabeLevelItemController>().prefabId;
    }
}

[Serializable]
public class StepEdit
{
    enum typeChanges
    {
        Put = 1,
        Rotate = 2,
        Delete = 3
    }

    public int itemId;
    public int stepId;
    public ItemTransform stepTransform;
}

[Serializable]
public class Level
{
    public int levelNum;
    public List<ItemTransform> items = new List<ItemTransform>();

    public void AddItem(GameObject item)
    {
        ItemTransform itemTransform = new ItemTransform(item);
        items.Add(itemTransform);
    }
}

public class Levels
{
    public List <Level> levels = new List<Level>();
}