using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISaveLevelController : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;
    public GameObject levelsGroup;
    public LevelManager levelManager;

    void Start()
    {
        levelManager = LevelManager.instanse;
    }
    
    void Update()
    {
        
    }

    void SaveLevel()
    {

    }

    void LoadLevel()
    {

    }

    
}
