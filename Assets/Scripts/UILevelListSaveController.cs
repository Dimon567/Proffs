using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelListSaveController : MonoBehaviour
{
    [SerializeField] GameObject Button;
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Clear();
        for (int i = 0; i < LevelManager.instanse.levelsList.levels.Count; i++)
        {
            GameObject button = Instantiate(Button, this.transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Level "+(i+1).ToString();
        }
    }

    public void Clear()
    {
        foreach (Transform level in GetComponentInChildren<Transform>())
        {
            Destroy(level.gameObject);
        }
    }
}
