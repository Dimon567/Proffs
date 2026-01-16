using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera _editorCamera;
    [SerializeField] private Camera _playCamera;
    [SerializeField] private LevelEditor _levelEditor;
    [SerializeField] private Car _car;

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = LevelManager.instanse;
    }

    public void StartEditor()
    {
        Camera.main.gameObject.SetActive(false);
        _editorCamera.gameObject.SetActive(true);

    }

    public void Play()
    {
        if (levelManager.levelsList.levels.Count < 1)
        {
            return;
        }

        levelManager.LoadLevels();
        _levelEditor.LoadLevel();
        Camera.main.gameObject.SetActive(false);
        _playCamera.gameObject.SetActive(true);
        _car.gameObject.SetActive(true);
    }
    public void StartLevel()
    {

    }
}
