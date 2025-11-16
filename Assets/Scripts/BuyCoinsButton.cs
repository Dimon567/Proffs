using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class BuyCoins : MonoBehaviour
{
    [SerializeField] private int countCoins = 0;
    [SerializeField] GameObject paymentScreen;

    public void AddCoins()
    {
        StartCoroutine(Payment()); 
    }

    public IEnumerator Payment()
    {
        paymentScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        paymentScreen.SetActive(false);
        InventaryManager.instance.inventory.countCoins += countCoins;
        InventaryManager.instance.SaveInventory();
    }
}
