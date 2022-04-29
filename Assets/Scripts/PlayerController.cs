using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  //  [SerializeField] private Transform _playerTransform= null;
    [SerializeField] private float _speed = 0f;
    private bool _isPlayerMove = false;
    private string _playerDirect = "null";
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        //Move Up
        if (Input.GetKeyDown(KeyCode.W) && _isPlayerMove == false)
        {
            _isPlayerMove = true;
            _playerDirect = "up";
        }
        if (_isPlayerMove == true && _playerDirect == "up")
        {
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }
        //Move Down
        if (Input.GetKeyDown(KeyCode.S) && _isPlayerMove == false)
        {
            _isPlayerMove = true;
            _playerDirect = "down";
        }
        if (_isPlayerMove == true && _playerDirect == "down")
        {
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        }
        //Move Left
        if (Input.GetKeyDown(KeyCode.A) && _isPlayerMove == false)
        {
            _isPlayerMove = true;
            _playerDirect = "left";
        }
        if (_isPlayerMove == true && _playerDirect == "left")
        {
            transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        }
        //Move Right
        if (Input.GetKeyDown(KeyCode.D) && _isPlayerMove == false)
        {
            _isPlayerMove = true;
            _playerDirect = "right";
        }
        if (_isPlayerMove == true && _playerDirect == "right")
        {
            transform.Translate(0, 0, 1 * _speed * Time.deltaTime);
        }
    }
}
