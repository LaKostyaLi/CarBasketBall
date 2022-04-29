using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    private bool _isPlayerMove = false;
    private string _playerDirect = "null";
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MovePlayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.tag != "ground")
            {
                _isPlayerMove = false;
                _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Death");
        }
        if (collision.gameObject.tag == "Finish")
        {
            _speed = 0f;
            Debug.Log("Yeah!");
        }
    }
    private void MovePlayer()
    {
        //Move Up
        if (Input.GetKeyDown(KeyCode.W) && _isPlayerMove == false && _playerDirect != "up")
        {
            _isPlayerMove = true;
            _playerDirect = "up";
            _rigidBody.constraints = RigidbodyConstraints.None;
        }
        if (_isPlayerMove == true && _playerDirect == "up")
        {
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }
        //Move Down
        if (Input.GetKeyDown(KeyCode.S) && _isPlayerMove == false && _playerDirect != "down")
        {
            _isPlayerMove = true;
            _playerDirect = "down";
            _rigidBody.constraints = RigidbodyConstraints.None;
        }
        if (_isPlayerMove == true && _playerDirect == "down")
        {
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        }
        //Move Left
        if (Input.GetKeyDown(KeyCode.A) && _isPlayerMove == false && _playerDirect != "left")
        {
            _isPlayerMove = true;
            _playerDirect = "left";
            _rigidBody.constraints = RigidbodyConstraints.None;
        }
        if (_isPlayerMove == true && _playerDirect == "left")
        {
            transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        }
        //Move Right
        if (Input.GetKeyDown(KeyCode.D) && _isPlayerMove == false && _playerDirect != "right")
        {
            _isPlayerMove = true;
            _playerDirect = "right";
            _rigidBody.constraints = RigidbodyConstraints.None;
        }
        if (_isPlayerMove == true && _playerDirect == "right")
        {
            transform.Translate(0, 0, 1 * _speed * Time.deltaTime);
        }
    }
}
