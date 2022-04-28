using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Rigidbody _rb;

    [Header("Controls")]
    public float Accel; //ускорение
    public float Brake; //ториоз
    public float Steering; //поворт


    [Header("Vehicle Settings")]
    public float EnginePower = 250f;
    public float BrakeForce = 10000f;
    public float Angle = 35f;

    [Header ("Wheels")]
    public WheelCollider[] FrontWheels;
    public WheelCollider[] BackWheels;

    public Vector3 CentreMass; //центр массы

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = CentreMass;
    }

    private void Update()
    {
        
    }
}
