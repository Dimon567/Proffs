using NUnit.Framework;
using System;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class UIBackgroundsShopController : MonoBehaviour
{
    public Image curImage;

    GameObject shop;
    Background[] backgrounds = new Background[] {
       new Background(){salary = 0, id = 1 },
       new Background(){salary = 100, id = 2 },
       new Background(){salary = 1000, id = 3 }
    };
    InventaryManager invManager;
    
    void Start()
    {
        invManager = InventaryManager.instance;
        shop = GetComponent<GameObject>();
    }

    void Update()
    {
        
    }

    void UpdateUIBoughtBackgrounds()
    {
        foreach (UIItemShopBackgroundsController item in shop.GetComponentsInChildren<UIItemShopBackgroundsController>())
        {
            item.UpdateUIBought();
        }
    }
}

[Serializable]
public class Background
{
    public int salary = 0;
    public int id;
}
