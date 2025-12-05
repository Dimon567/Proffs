using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{ 

    void FixedUpdate()
    {
        //MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 shift = Vector3.zero;
        Transform transform = GetComponent<Transform>();

        if(Input.mousePosition.x > Screen.width - 100)
        {
            shift.x -= Input.mousePosition.x - Screen.width - 100;
        }
        else if (Input.mousePosition.x < 100)
        {
            shift.x += Input.mousePosition.x - 100;
        }

        if (Input.mousePosition.y > Screen.height - 100 )
        {
            shift.y -= Input.mousePosition.y - Screen.height - 100;
        }
        else if (Input.mousePosition.y < 100)
        {
            shift.y += Input.mousePosition.y - 100;
        }
       
        transform.position = Vector3.Lerp(transform.position, transform.position + shift, Time.deltaTime * 0.02f);
    }
}
