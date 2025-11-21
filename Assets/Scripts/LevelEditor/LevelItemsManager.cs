using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;
using JetBrains.Annotations;
using System.IO;

public class LevelManager : MonoBehaviour
{
    public LevelManager instanse;
    public List<StepEdit> editSteps;
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
            JsonUtility.FromJson<Levels>(json);
        }
    }

    public void SaveLevels()
    {
        string json = JsonUtility.ToJson(path, true);
        File.WriteAllText(path, json);
    }

    public void AddItem(GameObject item)
    {
        Transform transform = item.transform;
        ItemTransform itemTransform = new ItemTransform();

        itemTransform.position = transform.position;
        //itemTransform.rotation = transform.transform.rotation.z;

    }
}

[Serializable]
public class ItemTransform
{
    public Vector3 position;
    public int rotation;
    public int id;
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
}

public class Levels
{
    public List <Level> levels = new List<Level>();
}