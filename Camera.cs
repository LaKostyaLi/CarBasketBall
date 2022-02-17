using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _car;

    private Vector3 _offset = new Vector3(0f, 2f, -4f); //сдвиг по 3 осям относительно машины
    private float _speed = 10f; //скорость поворота камеры

    // Update is called once per frame
    void FixedUpdate()
    {
        var tragetPosition = _car.TransformPoint(_offset); //изменённая позиция машины
        transform.position = Vector3.Lerp(transform.position, tragetPosition, _speed*Time.deltaTime);

        var direction = _car.position - transform.position; 
        var rotation = Quaternion.LookRotation(direction, Vector3.up); //поворот камеры

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speed*Time.deltaTime);
    }
}
