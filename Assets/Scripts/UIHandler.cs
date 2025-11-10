using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] public Object StartUI
    {
        set
        {
            curUI = value;
        }
    }

    private Object curUI;
    void Start()
    {
        
    }

    void Update()
    {
           
    }

    public void ShowUI(Object ui)
    {
        
    }
}
