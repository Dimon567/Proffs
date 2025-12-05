using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Searcher;
using TMPro.Examples;


public class LevelEditor : MonoBehaviour
{
    public GameObject levelGroup;
    public Button roundButton;
    public Button deleteButton;

    private LevelItems levelPrefabs;
    private GameObject currentItemPrefab;
    private bool isState = false;
    private Level currentLevel;

    public event Action<int> OnSelected;

    private void Start()
    {
        levelPrefabs = GetComponent<LevelItems>();
        UIItemController.OnSelected += SpawnItem;
        roundButton.onClick.AddListener(RotateItem);
        deleteButton.onClick.AddListener(DeleteItem);
    }

    private void SpawnItem(int index)
    {
        if(isState || currentItemPrefab == null)
        {
            GameObject prefab = levelPrefabs.prefabs[index];
            GameObject item = Instantiate(prefab, levelGroup.transform);
            PrefabeLevelItemController prefabController = item.AddComponent<PrefabeLevelItemController>();

            prefabController.prefabId = index;
            currentItemPrefab = item;
            isState = false;
        }
    }

    private void OnRightClick()
    {
        PutItem();
    }

    void PutItem()
    {
        currentItemPrefab.GetComponent<PrefabeLevelItemController>().enabled = false;
        isState = true;
    }

    private void RotateItem()
    {
        if (isState)
        {
            currentItemPrefab.transform.Rotate(0, 0, 90);
        }
    }

    private void DeleteItem()
    {
        if (isState)
        {
            Destroy(currentItemPrefab);
            currentItemPrefab = null;
        }
    }

    public void SaveLevel()
    {
        currentLevel = new Level();
        if ()
        {
            LevelManager.instanse.levelsList.levels.Add(currentLevel);
        }
        

        for (int  i = 0; gameObject.transform.childCount > i; i++)
        {
            Transform item = levelGroup.transform.GetChild(i);
            currentLevel.AddItem(item);
        }

       LevelManager.instanse.SaveLevels();
    }

    public void LoadLevel()
    {
        ClearLevel();
        Level currentLevel = LevelManager.instanse.levelsList.levels[0];

        foreach (ItemTransform item in currentLevel.items)
        {
            GameObject prefab = levelPrefabs.prefabs[item.id];
            GameObject physicItem = Instantiate(prefab, levelGroup.transform);

            physicItem.transform.position = item.position;
            physicItem.transform.eulerAngles = item.rotation;
            physicItem.AddComponent<PrefabeLevelItemController>();
            physicItem.GetComponent<PrefabeLevelItemController>().enabled = false;
        }
    }

    public void ClearLevel()
    {
        foreach (Transform item in levelGroup.GetComponentInChildren<Transform>()) {
            Destroy(item.gameObject);
        }
    }
}
