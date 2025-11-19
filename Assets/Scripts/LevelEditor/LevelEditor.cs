using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelEditor : MonoBehaviour
{
    public GameObject levelGroup;
    private LevelItems levelPrefabs;
    private GameObject currentItemPrefab;

    private void Start()
    {
        levelPrefabs = gameObject.GetComponent<LevelItems>();
        UIItemController.OnSelected += SelectCurrentItem;
    }

    private void SelectCurrentItem(int index)
    {
        currentItemPrefab = levelPrefabs.prefabs[index];
        SpawnPrefab();
    }

    private void FixedUpdate()
    {
        MovePrefab();
    }

    void MovePrefab()
    {
        if (currentItemPrefab == null)
        {
            return;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 position = new Vector3(0,0,0);
        currentItemPrefab.transform.position = position;
        Debug.Log(currentItemPrefab.transform.position.ToString());
    }

    private void SpawnPrefab()
    {
        GameObject item = Instantiate(currentItemPrefab, levelGroup.transform);
        item.AddComponent<PrefabeLevelItemController>();
        
    }
    
    
}
