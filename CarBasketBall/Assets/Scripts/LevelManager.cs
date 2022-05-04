using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _levelNumber = 1;
    [SerializeField] private int _tryNumber = 1;
    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private PlayerController _player;
    [SerializeField] private SaveSystem _saveSystem;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LevelNumber = _saveSystem.gameData.Level;
        TryNumber = _saveSystem.gameData.Try;
        int _currentLevelPrefab = _levelNumber % _levels.Count;

        if (_currentLevelPrefab == 0)
        {
            _currentLevelPrefab = _levels.Count;
        }
        LevelStart(_levels[_currentLevelPrefab - 1]);
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
                _saveSystem.gameData.Level = value;
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
                _saveSystem.gameData.Try = value;
            }
        }
    }
    public void LevelStart(GameObject lvl)
    {
        Instantiate(lvl.gameObject, Vector3.zero, Quaternion.identity);
    }
    public void LevelComplete()
    {
        Debug.Log("Yeah! Level " + LevelNumber + " completed! Number of attempts:" + TryNumber);
        //GameAnalyticsSDK here
        //IronSource ADS here
        LevelNumber = LevelNumber + 1;
        TryNumber = 1;
    }
}
