using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class LevelManager : MonoBehaviour
{
    // [SerializeField] private SaveSystem _saveSystem = null;
    [SerializeField] private int _levelNumber = 1;
    [SerializeField] private int _tryNumber = 1;
    [SerializeField] private PlayerController _player;
    [SerializeField] private List<GameObject> _dictionary;
    private InterstitialADS _ads;
    public int _currentlevel = 0;
    private GameObject _newLvl = null;



    private void Start()
    {
        // _levelNumber = _saveSystem.gameData.Level;
        //  _tryNumber = _saveSystem.gameData.Try;
        DontDestroyOnLoad(gameObject);
        LevelStart();

    }

    public int LevelNumber
    {
        get
        {
            return _levelNumber;
        }
        set
        {
            if (value >= 1)
            {
                _levelNumber = value;
            }
        }
    }
    public int TryNumber
    {
        get
        {
            return _tryNumber;
        }
        set
        {
            if (value >= 1)
            {
                _tryNumber = value;
            }
        }
    }


    public void LevelStart()
    {
          _newLvl =  Instantiate(_dictionary[_currentlevel], new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void LevelComplete()
    {
        Debug.Log("Yeah! Level " + LevelNumber + " completed! Number of attempts:" + TryNumber);
        Analytics.CustomEvent($"LevelComplete + {_levelNumber}");

        Destroy(_newLvl);
       // _ads.ShowADS();
        LevelNumber = LevelNumber + 1;
        _currentlevel = _currentlevel + 1;
        if (_currentlevel > 2)
        {
            _currentlevel = 0;
        }
        TryNumber = 1;
        LevelStart();
        _player.TeleportPlayerToStart();
    }
}