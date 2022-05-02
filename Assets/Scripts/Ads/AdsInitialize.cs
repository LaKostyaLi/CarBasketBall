using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitialize : MonoBehaviour, IUnityAdsInitializationListener 
{
    [SerializeField] string _androidID = "4736107";
    [SerializeField] string _iosId = "4736106";
    [SerializeField] bool _testMode = true;

    private string _gameID;

    private void Awake()
    {
        _gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iosId : _androidID;
        InitializeAds();
    }

    public void InitializeAds()
    {
       Advertisement.Initialize(_gameID, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log($"Unity Ads So Good!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Failed");
    }
}
