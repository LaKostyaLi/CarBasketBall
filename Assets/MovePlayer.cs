using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] public float _speed = 10;
   // [SerializeField] Transform _arms;
    [SerializeField] Transform _ball;
    [SerializeField] Transform _up;
    [SerializeField] Transform _target;
    [SerializeField] Transform _down;

    

    private bool _isBallMe = true;
    private bool _isBallFlying = false; //будет true когда мяч в полёте
    private float _t = 0; //время полёта

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * _speed * Time.deltaTime;
        transform.LookAt(transform.position + direction); //направление нашего персонажа

        if (_isBallMe)
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                _ball.position = _up.position;
               // _arms.localEulerAngles = Vector3.right * 180;

                transform.LookAt(_target.position);

            }
            else
            {
                //_arms.localEulerAngles = Vector3.right * 0;
                _ball.position = _down.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 3));//для того чтобы мяч прыгал (нужно Abs значение) 
               // _arms.localEulerAngles = Vector3.right * 0;
            }
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                _isBallMe = false;
                _isBallFlying = true;
                _t = 0;
            }
        }

        if (_isBallFlying)  //полёт мяча
        {
            _t += Time.deltaTime;
            float duration = 1f;
            float t01 = _t / duration;

            Vector3 a = _up.position;
            Vector3 b = _target.position;
            Vector3 pos = Vector3.Lerp(a, b, t01);

            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f); //для того чтобы мяч не летел прямо

            _ball.position = pos + arc;


            if (t01 >= 1)
            {
                _isBallFlying = false;
                _ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other) //поднимаем мяч с пола
    {
        if (!_isBallMe && !_isBallFlying)
           // if (other.tag == "Ball" && !_isBallMe && !_isBallFlying)
            {
                _isBallMe = true;
                _ball.GetComponent<Rigidbody>().isKinematic = true;
            }
    }
}



    
