using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemShopBackgroundsController : MonoBehaviour
{
    public GameObject blockSalary;
    public TextMeshProUGUI textSalary;
    public Toggle toggeleSelecter;
    public Button buyButton;
    public GameObject toggelGroup;
    [SerializeField] int id;
    [SerializeField] int salary;
    InventaryManager invManager;

    void Start()
    {
        textSalary.text = salary.ToString();
        invManager = InventaryManager.instance;
        buyButton.onClick.AddListener(BuyBackground);
        toggeleSelecter.onValueChanged.AddListener(OnSelected);

        UpdateUIBought();
        UpdateUISelectCurrent();
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
    void UpdateUIBought()
    {
        if (invManager.WasBackgroundbought(id))
        {
            blockSalary.SetActive(false);
            buyButton.gameObject.SetActive(false);
            toggeleSelecter.gameObject.SetActive(true);
            toggeleSelecter.group = toggelGroup.gameObject.GetComponent<ToggleGroup>();
        }
        else
        {
            blockSalary.SetActive(true);
            buyButton.gameObject.SetActive(true);
            toggeleSelecter.gameObject.SetActive(false);
            toggeleSelecter.group = null;
        }
    }
    void BuyBackground()
    {
        if (!invManager.SubCoins(salary))
        {
            return;
        }

        invManager.inventory.boughtBackgrounds.Add(id);
        invManager.inventory.currentBackground = id;
        toggeleSelecter.Select();
        invManager.SaveInventory();
        UpdateUIBought();

    }
    void OnSelected(bool value)
    {
        if (value)
        {
            invManager.inventory.currentBackground = id;
            invManager.SaveInventory();
        }   
    }
    void UpdateUISelectCurrent()
    {
        if (invManager.inventory.currentBackground == id)
        {
            toggeleSelecter.isOn = true;
        }
    }

}
