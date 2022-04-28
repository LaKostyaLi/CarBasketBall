using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //поля для колёс
    [SerializeField] private Transform _trasformFrLeft;
    [SerializeField] private Transform _trasformFrRight;
    [SerializeField] private Transform _trasformLeft;
    [SerializeField] private Transform _trasformRight;

    //поля для колайдеров колёс
    [SerializeField] private WheelCollider  _colliderFrLeft;
    [SerializeField] private WheelCollider _colliderFrRight;
    [SerializeField] private WheelCollider _colliderLeft;
    [SerializeField] private WheelCollider _colliderRight;
    

    [SerializeField] private float _force; //мощность двигателя
    [SerializeField] private float _maxAngle; //градус поворота руля


   

    // Для физики лучше осталять FixedUpdate
    private void FixedUpdate()
    {
        //добавляем крутящие моменты передних колёс
        //MotorTorque - крутящий момент передающийся на колесо без учета сил трения
        _colliderFrLeft.motorTorque = Input.GetAxis("Vertical") * _force * 100000;
        _colliderFrRight.motorTorque = Input.GetAxis("Vertical") * _force*100000;
        _colliderLeft.motorTorque = Input.GetAxis("Vertical") * _force * 100000;
        _colliderRight.motorTorque = Input.GetAxis("Vertical") * _force * 100000;
      

        //торможение для всех 4ых колёс
        if (Input.GetKey(KeyCode.Space))
        {
            _colliderFrLeft.brakeTorque = _force * 100000000f;
            _colliderFrRight.brakeTorque = _force * 100000000f;
            _colliderLeft.brakeTorque = _force * 100000000f;
            _colliderRight.brakeTorque = _force * 100000000f;
        }
        else 
        {
            _colliderFrLeft.brakeTorque = 0f;
            _colliderFrRight.brakeTorque = 0f;
            _colliderLeft.brakeTorque = 0f;
            _colliderRight.brakeTorque = 0f;
        }

        //повороты коллайдеров передних колёс
        _colliderFrLeft.steerAngle = _maxAngle * Input.GetAxis("Horizontal");
        _colliderFrRight.steerAngle = _maxAngle * Input.GetAxis("Horizontal");

        RotateWheel(_colliderFrLeft, _trasformFrLeft);
        RotateWheel(_colliderFrRight, _trasformFrRight);
        RotateWheel(_colliderLeft, _trasformLeft);
        RotateWheel(_colliderRight, _trasformRight);
    }

    //метод поворта самих моделей колёс
    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position; 
        Quaternion rotation; //поворт

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }
}
