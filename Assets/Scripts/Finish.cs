using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource = null;
    private int _levelNumber = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelComplete(_levelNumber);
        }
    }
    private void LevelComplete(int levelNumberInt)
    {
        _audioSource.Play();
        Debug.Log("Yeah! Level " + levelNumberInt + " completed!");
        //GameAnalyticsSDK here
        //IronSource ADS here
        _levelNumber += 1;
    }

}