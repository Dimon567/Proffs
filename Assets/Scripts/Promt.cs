using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Promt : MonoBehaviour
{

    [SerializeField] private string promtText = "";
    [SerializeField] private int timeWait = 2;
    [SerializeField] private TextMeshProUGUI promtObject;
    private Coroutine currentCor;

    private void Start()
    {
        promtObject.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (!promtObject.gameObject.activeSelf)
        {
            return;
        }
        var promtTransform = promtObject.rectTransform.transform;
        promtTransform.position = Vector3.Lerp(promtTransform.position, CalcPosition(), Time.deltaTime * 5);
    }

    public Vector3 CalcPosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 shift = new Vector2(promtObject.rectTransform.rect.width / 2, 0);
        shift.x += 10;
        promtObject.ForceMeshUpdate();

        if (Screen.width / 2 < mousePosition.x)
        {
            shift *= new Vector2(-1, 1);
        }
        else { shift.x += 20; }

        return shift * promtObject.canvas.scaleFactor + mousePosition; 
    }

    public void ShowPromt()
    {
        currentCor = StartCoroutine(Show());
    }

    public IEnumerator Show()
    {
        yield return new WaitForSeconds(timeWait);
        promtObject.text = promtText;
        promtObject.rectTransform.transform.position = CalcPosition();
        promtObject.gameObject.SetActive(true);
    }

    public void HidePromt()
    {
        promtObject.gameObject.SetActive(false);
        StopCoroutine(currentCor);
        
    }
}
