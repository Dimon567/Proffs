using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Searcher;


public class LevelEditor : MonoBehaviour
{
    public GameObject levelGroup;
    public Button roundButton;
    public Button deleteButton;

    private LevelItems levelPrefabs;
    private GameObject currentItemPrefab;
    private bool isState = false;
    public Level currentLevel;

    public event Action<int> OnSelected;


    private void Start()
    {
        levelPrefabs = GetComponent<LevelItems>();
        UIItemController.OnSelected += SpawnItem;
        roundButton.onClick.AddListener(RotateItem);
        deleteButton.onClick.AddListener(DeleteItem);
        currentLevel = new Level();
    }

    private void SpawnItem(int index)
    {
        if(isState || currentItemPrefab == null)
        {
            GameObject prefab = levelPrefabs.prefabs[index];
            GameObject item = Instantiate(prefab, levelGroup.transform);
            item.AddComponent<PrefabeLevelItemController>();
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
        currentItemPrefab.GetComponent<PrefabeLevelItemController>().isMove = false;
        isState = true;
    }

    private void RotateItem()
    {
        if(!isState)
        {
            return;
        }

        currentItemPrefab.transform.Rotate(0,0,90);
    }

    private void DeleteItem()
    {
        if(!isState)
        {
            return;
        }

        currentItemPrefab.GetComponent<PrefabeLevelItemController>().DestroyItem();
        currentItemPrefab = null;
    }
}
