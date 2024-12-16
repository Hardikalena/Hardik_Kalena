using System;
using UnityEngine;
using UnityEngine.Advertisements;

// Handles the initialization of Unity Ads
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidGameID; // Game ID for Android platform
    public string iosGameID; // Game ID for iOS platform
    public bool testMode; // Determines if ads are run in test mode
    private string gameID; // Stores the appropriate game ID based on platform

    private void Awake()
    {
        InitializeAds(); // Initialize ads when the object awakens
    }

    // Sets up Unity Ads based on the platform and initializes them
    private void InitializeAds()
    {
#if UNITY_IOS
        gameID = iosGameID; // Use the iOS game ID
#elif UNITY_ANDROID
        gameID = androidGameID; // Use the Android game ID
#elif UNITY_EDITOR
        gameID = androidGameID; // Use the Android game ID in the Unity Editor
#endif 
        // Check if Unity Ads is not already initialized and is supported
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameID, testMode, this); // Initialize Unity Ads
        }
    }

    // Callback for successful Unity Ads initialization
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialization Complete"); // Log success message
    }

    // Callback for failed Unity Ads initialization
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}"); // Log error details
    }
}
