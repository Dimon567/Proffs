using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _centerOfMass;
    [SerializeField] private GameObject _wheel1;
    [SerializeField] private GameObject _wheel2;

    public void SpawnCar()
    {
        //gameObject.GetComponent<Rigidbody2D>().centerOfMass = _centerOfMass.position;
        gameObject.transform.position = _spawnPoint.position;
        Stop();
    }

    public void SwitchPhysics(bool status)
    {
        GetComponent<Rigidbody2D>().simulated = status;
        _wheel1.GetComponent<Rigidbody2D>().simulated = status;
        _wheel2.GetComponent<Rigidbody2D>().simulated= status;
    }

    public void Move()
    {
        _wheel1.GetComponent<WheelJoint2D>().useMotor = true;
        _wheel2.GetComponent<WheelJoint2D>().useMotor = true;
    }

    public void Stop()
    {
        _wheel1.GetComponent<WheelJoint2D>().useMotor = false;
        _wheel2.GetComponent<WheelJoint2D>().useMotor = false;
    }

}
