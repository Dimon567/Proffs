using TMPro;
using UnityEngine;
using System;

public class UICoinsCounterController : MonoBehaviour
{

    void Start()
    {
        UpdateCounter();
    }

    void Update()
    {
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        float count = InventaryManager.instance.inventory.countCoins;
        string str = count.ToString();

        if (count >= 1000)
        {
            str = Math.Round(count / 1000, 1).ToString() + "k";
        }

        GetComponent<TMP_Text>().text = str;
    }
}
