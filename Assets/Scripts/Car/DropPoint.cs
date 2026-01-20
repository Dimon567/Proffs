using UnityEngine;

public class DropPoint : MonoBehaviour
{
    void Start()
    {
        
    }

    public void AttachDetail(GameObject detail)
    {
        Instantiate(detail);
        detail.transform.parent = transform;
    }
}
