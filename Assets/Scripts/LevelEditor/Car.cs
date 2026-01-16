using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _centerOfMass;

    void Start()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().centerOfMass = _centerOfMass.position;
        //gameObject.transform.position = _spawnPoint.position;
    }

    void Update()
    {
        
    }
}
