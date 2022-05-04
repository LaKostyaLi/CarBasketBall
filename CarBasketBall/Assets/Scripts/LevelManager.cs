﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _levelNumber = 1;
    [SerializeField] private int _tryNumber = 1;
    [SerializeField] private GameObject lvl1;
    [SerializeField] private GameObject lvl2;
    [SerializeField] private GameObject lvl3;
    [SerializeField] private PlayerController _player;
    GameObject S;


    private void Start()
    {
        // DontDestroyOnLoad(gameObject);
        LevelStart(lvl1);
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
    public void LevelStart(GameObject lvl)
    {
        S = Instantiate(lvl.gameObject, Vector3.zero, Quaternion.identity);
    }
    public void LevelComplete()
    {
        Debug.Log("Yeah! Level " + LevelNumber + " completed! Number of attempts:" + TryNumber);
        //GameAnalyticsSDK here
        //IronSource ADS here
        LevelNumber = LevelNumber + 1;
        TryNumber = 1;
        //level destroy + tp player to 0 0 0
        
        Destroy(gameObject);
        Destroy(lvl1);
        LevelStart(lvl2);
    }
}
