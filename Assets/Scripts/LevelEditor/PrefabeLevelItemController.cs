using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PrefabeLevelItemController : MonoBehaviour
{
    Transform transform;

    RaycastHit hit;
    bool isHit = false;

    private void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        transform.position.Lerp(transform.position, MoveToMouse(), Time.deltaTime);
    }

    private Vector3 MoveToMouse()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        isHit = Physics.Raycast(ray, out hit);

        //if (!isHit)
        //{
        //    return transform.position;
        //}
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * hit.distance, Color.red);
        Debug.Log("Raycast hit: " + hit.collider.name);

        //transform.position = mousePosition;

        return new Vector3(transform.localPosition.x, transform.localPosition.y, 0);


    }

}
