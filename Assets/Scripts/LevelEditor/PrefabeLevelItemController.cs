using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PrefabeLevelItemController : MonoBehaviour
{
    Transform transform;
    public int prefabId;

    private void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
          transform.position = Vector3.Lerp(transform.position, MovePositionToMouse(), Time.deltaTime * 10);
    }

    private Vector3 MovePositionToMouse()
    {
        float distance = GetComponent<Transform>().parent.transform.position.z - Camera.main.transform.position.z;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        RaycastHit hit;
        Ray ray = new Ray(mousePosition, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            return new Vector3(hit.point.x, hit.point.y, transform.parent.position.z);
        }

        return transform.position;
    }
 

}
