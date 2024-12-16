using UnityEngine;
using UnityEngine.Advertisements;
public class InterstitialAd : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    public static InterstitialAd Instance;
    public string androidID;
    public string iosID;
    string adUnityID;


    private void Awake()
    {
        Instance = this;
        if(Application.platform == RuntimePlatform.Android)
        {
            adUnityID = androidID;
        }
        else if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adUnityID = iosID;
        }
        else if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            adUnityID = androidID;
        }
    }

    public void LoadAD()
    {
        Advertisement.Load(adUnityID,this);
    }

    public void ShowAD()
    {
        Advertisement.Show(adUnityID,this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Load Successful");
        ShowAD();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Load Failed");
        Debug.Log(message);
        Debug.Log(error);
        Debug.Log(placementId);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Show Failed");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Showing");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ads Show Complete");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }
}
