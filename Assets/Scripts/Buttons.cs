using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public InterstitialADS _ads;


    [SerializeField] private GameObject _buttonStart;
    [SerializeField] private GameObject _buttonMenu;
    [SerializeField] private GameObject _buttonExit;
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private GameObject _panel;

    public void OnClickStart()
    {
        _ads.ShowADS();

       
        _panel.SetActive(false);
        _buttonStart.SetActive(false);
        _buttonMenu.SetActive(true);
        _buttonExit.SetActive(false);
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
