using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrentBackgroundTextureUI : MonoBehaviour
{
    [SerializeField] Sprite[] backgroundTexture;
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        image.overrideSprite = backgroundTexture[InventaryManager.instance.inventory.currentBackground - 1];
    }
}
