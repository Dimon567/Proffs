using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventaryManager : MonoBehaviour
{
    public string path;
    public Inventory inventory;
    public static InventaryManager instance;

    void Awake()
    {
        instance = this;
        path = Path.Combine(Application.persistentDataPath, "inventary.json");
        LoadInventory();
    }

    public bool SubCoins(int count)
    {
        if (inventory.countCoins - count < 0)
        {
            return false;
        }

        inventory.countCoins -= count;
        return true;
    }

    public bool AddCoins(int count)
    {
        if (count <= 0)
        {
            return false;
        }
        count += count;
        return true;
    }

    public void LoadInventory()
    {
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            inventory = JsonUtility.FromJson<Inventory>(json);
            return;
        }
            
        inventory = new Inventory();
    }

    public void SaveInventory()
    {
        string json = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(path, json);
    }

}

[Serializable]
public class Inventory
{
    public int countCoins = 0;
    public List<int> boughtBackgrounds = new List<int>(){ 1 };
    public int selectBackground = 1;
}
