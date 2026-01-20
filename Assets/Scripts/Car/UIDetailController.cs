using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIIDetailController : MonoBehaviour
{
    private bool move = false;
    private Transform detailTransform;
    [SerializeField] GameObject _detailPrefab;
    

    private void Start()
    {
        detailTransform = transform.GetChild(0);
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && move)
        {
            MoveToMouse();
            Debug.Log("Start move");
        }
        else if(!Input.GetMouseButton(0)){
            //Return();
            DropDetail();
        }
        else
        {
            //move = false;
            
        }
    }

    void MoveToMouse()
    {
        detailTransform.parent = GameObject.Find("Canvas").transform;
        Vector2 nextPosition = Input.mousePosition;
        //detailTransform.localScale = Vector3.one;
        //Debug.Log(nextPosition);
        //nextPosition = _canvasCamera.ScreenToWorldPoint(nextPosition);
        //Debug.Log(nextPosition);
        //nextPosition = detailTransform.InverseTransformPoint(nextPosition);
        //Console.WriteLine(nextPosition);

        //Camera canvasCamera = GameObject.Find("Canvas Camera").GetComponent<Camera>();
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), nextPosition,
        //    canvasCamera, out nextPosition);
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(detailTransform.parent.GetComponent<RectTransform>(), nextPosition, GameObject.Find("Canvas Camera").GetComponent<Camera>(), out nextPosition);
        detailTransform.position  = Vector2.Lerp(detailTransform.position, nextPosition, 0.2f);
    }

    void Return()
    {
        detailTransform.parent = GetComponent<Transform>();
        if (detailTransform.position == Vector3.zero) return;
        detailTransform.localPosition = Vector2.Lerp(detailTransform.localPosition, Vector2.zero, 0.4f);
    }

    void DropDetail()
    {
        Debug.Log("ray");
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = new Ray(mouseposition, Camera.main.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(mouseposition, Camera.main.transform.forward, Color.red, 100.0f);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit");
            hit.collider.gameObject.GetComponent<DropPoint>().AttachDetail(_detailPrefab);
            gameObject.SetActive(false);
        }
    }

    void OnClick()
    {
        Debug.Log("Click");
        move = true;
    }
}
