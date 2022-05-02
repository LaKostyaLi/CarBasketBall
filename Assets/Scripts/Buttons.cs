using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public InterstitialADS _ads;

    [SerializeField] private GameObject _level1;
    [SerializeField] private GameObject _level2;
    [SerializeField] private GameObject _level3;

    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _buttonStart;
    [SerializeField] private GameObject _buttonMenu;
    [SerializeField] private GameObject _buttonExit;

    [SerializeField] private GameObject _panel;

    public void OnClickStart()
    {
        _ads.ShowADS();
       
        GameObject[] _gameObjects;
        _gameObjects = GameObject.FindGameObjectsWithTag("Level_1");

        if (_gameObjects.Length==0)
        {
            Instantiate(_level1, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
        
        }
        _panel.SetActive(false);
        _buttonStart.SetActive(false);
        _buttonMenu.SetActive(true);
        _buttonExit.SetActive(false);
        _player.SetActive(true);
    }

    public void OnClickMenu()
    {
        _ads.ShowADS();
        _buttonStart.SetActive(true);
        _buttonMenu.SetActive(false);
        _buttonExit.SetActive(true);
        _panel.SetActive(true);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
