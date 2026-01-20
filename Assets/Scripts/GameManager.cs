using TMPro.EditorUtilities;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera _editorCamera;
    [SerializeField] private Camera _playCamera;
    [SerializeField] private LevelEditor _levelEditor;
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _tableObjects;
    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _carEditorUI;
    [SerializeField] private GameObject _levelSettingsUI;

    private Camera currentCamera;
    private GameObject currentUI;
    private Car carController;

    private static LevelManager levelManager;

    private void Start()
    {
        levelManager = LevelManager.instanse;
        currentCamera = Camera.main;
        currentUI = _mainMenuUI;
        carController = _car.GetComponent<Car>();
    }

    public void StartEditor()
    {
        SwitchCamera(_editorCamera);
        _tableObjects.SetActive(false);
    }

    public void LevelSettings(bool state)
    {
        _levelSettingsUI.SetActive(state);
        _editorCamera.GetComponent<CameraController>().enabled = !state;
    }

    public void Play()
    {
        if (levelManager.levelsList.levels.Count < 1)
        {
            return;
        }

        EditUI(_carEditorUI);

        _levelEditor.LoadLevel();

        _car.gameObject.SetActive(true);
        carController.SpawnCar();
        carController.SwitchPhysics(false);
    }

    public void StartLevel()
    {
        SwitchCamera(_playCamera);
        currentUI.SetActive(false);

        carController.SwitchPhysics(true);
        carController.Move();
    }

    public void Menu()
    {
        SwitchCamera(Camera.main);
        EditUI(_mainMenuUI);

        _tableObjects.SetActive(true);
        _car.gameObject.SetActive(false);
        _levelEditor.ClearLevel();
        
    }

    public void NextLevel()
    {

    }

    public void SwitchCamera(Camera nextCamera)
    {
        currentCamera.gameObject.SetActive(false);
        currentCamera = nextCamera;
        currentCamera.gameObject.SetActive(true);
    }

    public void EditUI(GameObject nextUI)
    {
        currentUI.SetActive(false);
        currentUI = nextUI;
        currentUI.SetActive(true);
    }
}
