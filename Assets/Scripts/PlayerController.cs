using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private LevelManager _levelManager = null;
    private bool _isPlayerMove = false;
    private string _playerDirect = "null";
    private Rigidbody _rigidBody;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
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
                MoveStop();
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            _levelManager.TryNumber = _levelManager.TryNumber + 1;
            MoveStop();
            _playerDirect = "null";
            transform.position = _startPosition;
            Debug.Log("Death. Try again.");
        }
    }
    private void MovePlayer()
    {
        //Move Up
        if (Input.GetKeyDown(KeyCode.W) && _isPlayerMove == false && _playerDirect != "up")
        {
            MoveStart("up");
        }
        if (_isPlayerMove == true && _playerDirect == "up")
        {
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }
        //Move Down
        if (Input.GetKeyDown(KeyCode.S) && _isPlayerMove == false && _playerDirect != "down")
        {
            MoveStart("down");
        }
        if (_isPlayerMove == true && _playerDirect == "down")
        {
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        }
        //Move Left
        if (Input.GetKeyDown(KeyCode.A) && _isPlayerMove == false && _playerDirect != "left")
        {
            MoveStart("left");
        }
        if (_isPlayerMove == true && _playerDirect == "left")
        {
            transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        }
        //Move Right
        if (Input.GetKeyDown(KeyCode.D) && _isPlayerMove == false && _playerDirect != "right")
        {
            MoveStart("right");
        }
        if (_isPlayerMove == true && _playerDirect == "right")
        {
            transform.Translate(0, 0, 1 * _speed * Time.deltaTime);
        }
    }
    private void MoveStart(string str)
    {
        _isPlayerMove = true;
        _playerDirect = str;
        _rigidBody.constraints = RigidbodyConstraints.None;
    }
    private void MoveStop()
    {
        _audioSource.Play();
        _isPlayerMove = false;
        _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}