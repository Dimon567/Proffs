using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrentBackgroundTextureUI : MonoBehaviour
{
    [SerializeField] Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>() {};
    Image image;
    private void Start()
    {
        sprites.Add(1, Resources.Load<Sprite>("Images/Textures/wall_1 preview"));
        sprites.Add(2, Resources.Load<Sprite>("Images/Textures/wall_2 preview"));
        sprites.Add(3, Resources.Load<Sprite>("Assets/Images/Textures/wall_3 preview"));
        image = GetComponent<Image>();
    }
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        image.overrideSprite = sprites[InventaryManager.instance.inventory.currentBackground];
    }
}
