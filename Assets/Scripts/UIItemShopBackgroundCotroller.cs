using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemShopBackgroundsController : MonoBehaviour
{
    public GameObject blockSalary;
    public TextMeshProUGUI textSalary;
    Image backgroundImage;
    InventaryManager invManager;

    void Start()
    {
        textSalary.text = "";
        invManager = InventaryManager.instance;
    }
    void Update()
    {
        UpdateUISalary();
    }
    void UpdateUISalary()
    {
        if (invManager.inventory.countCoins < 0)
        {
            textSalary.color = Color.red;
        }
        else {
            textSalary.color = Color.white;
        }
    }
    public void UpdateUIBought()
    {
        
        blockSalary.SetActive(false);
    }
    //public void BuyBackground()
    //{
    //    if (invManager.SubCoins(0))
    //    {
    //        invManager.inventory.backgrounds.Add(0);
    //    }
    //}

}
