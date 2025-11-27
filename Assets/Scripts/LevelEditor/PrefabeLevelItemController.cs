using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PrefabeLevelItemController : MonoBehaviour
{
    Transform transform;
    public bool isMove = true;
    public int prefabId;
    

    private void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (isMove)
        {
            transform.position = Vector3.Lerp(transform.position, MovePositionToMouse(), Time.deltaTime * 10);
        }
        //Debug.Log(transform.position);
    }
    private Vector3 MovePositionToMouse()
    {
        float distance = GetComponent<Transform>().parent.transform.position.z - Camera.main.transform.position.z;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        RaycastHit hit;
        Ray ray = new Ray(mousePosition, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red, hit.distance);
            return new Vector3(hit.point.x, hit.point.y, transform.parent.position.z);
        }

        Debug.DrawRay(ray.origin, ray.direction, Color.red, hit.distance);

        return transform.position;
    }

    public void DestroyItem()
    {
        gameObject.SetActive(false);
    }

}
