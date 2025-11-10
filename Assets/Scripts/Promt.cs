using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Promt : MonoBehaviour
{
    [SerializeField] private string promtText;
    [SerializeField] private int timeWait;
    [SerializeField] private TextMeshProUGUI promtObject;
    private Coroutine currentCor;

    private void Start()
    {
        promtObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!promtObject.gameObject.activeSelf)
        {
            return;
        }

        Vector3 shift = new Vector3(0, this.transform.GetComponent<Renderer>().bounds.size.y, 0);
        promtObject.gameObject.transform.position = promtObject.gameObject.transform.position + shift;
    }

    public void ShowPromt()
    {
        currentCor = StartCoroutine(Show());
    }

    public IEnumerator Show()
    {
        yield return new WaitForSeconds(timeWait);
        promtObject.text = promtText;
        promtObject.gameObject.SetActive(true);
    }

    public void HidePromt()
    {
        promtObject.gameObject.SetActive(false);
        StopCoroutine(currentCor);
        
    }
}
