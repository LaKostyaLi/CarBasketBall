using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialADS : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string _androidID = "Interstitial_Android";
    [SerializeField] private string _iosdID = "Interstitial_iOS";

    private string _adID;

    private void Awake()
    {
        _adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iosdID : _androidID;
        LoadADS();
    }

    public void LoadADS()
    {
        Debug.Log("Loading:" + _adID);
        Advertisement.Load(_adID, this);
    }

    public void ShowADS()
    {
        Debug.Log("Showing:" + _adID);
        Advertisement.Show(_adID, this);

    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadADS();
    }
}
