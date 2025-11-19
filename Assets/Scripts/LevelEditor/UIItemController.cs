using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class UIItemController : MonoBehaviour
{
    public static event Action<int> OnSelected;
    Transform parent;
    Button curButton;

    private void Start()
    {
       curButton = GetComponent<Button>();
       parent = GetComponent<Transform>().parent;

       curButton.onClick.AddListener(OnHolded);
    }

    public void OnHolded()
    {
        int index = GetIndex();

        if (index != -1)
        {
            OnSelected?.Invoke(index);
        }
    }

    private int GetIndex()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            if (GetComponent<Transform>().GetInstanceID() == parent.GetChild(i).GetInstanceID())
            {
                return i;
            }
        }
        return -1;
    }

}
