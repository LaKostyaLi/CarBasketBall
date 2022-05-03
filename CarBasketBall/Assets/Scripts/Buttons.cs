using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _inGameMenu;

    public void Awake()
    {
        _mainMenu.SetActive(true);
    }
    public void OnClickStart()
    {
        _mainMenu.SetActive(false);
        _inGameMenu.SetActive(true);
    }

    public void OnClickMenu()
    {
        _mainMenu.SetActive(true);
        _inGameMenu.SetActive(false);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
