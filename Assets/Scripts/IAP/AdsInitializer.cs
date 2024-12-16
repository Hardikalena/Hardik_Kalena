using System;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsInitializer : MonoBehaviour,IUnityAdsInitializationListener
{
    public string androidGameID;
    public string iosGameID;
    public bool testMode;
    string gameID;
    private void Awake()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
#if UNITY_IOS
        gameID = iosGameID;
#elif UNITY_ANDROID
        gameID = androidGameID;
#elif UNITY_EDITOR
        gameID = androidGameID;
#endif 
        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameID,testMode,this);
        }

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialization Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Unity Ads Initialization Failed");
    }

}
