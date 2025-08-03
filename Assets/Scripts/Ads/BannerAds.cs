using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Properties")]
    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId;

    void Awake()
    {
        InitializeUnityAds();
    }

    public void InitializeUnityAds()
    {
        #if UNITY_IOS
                _adUnitId = _iOSAdUnitId;
        #elif UNITY_ANDROID
                _adUnitId = _androidAdUnitId;
        #endif

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    // Load content to the Ad Unit:
    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(_adUnitId, options);
    }

    private void OnBannerError(string message)
    {
        Debug.Log("Banner Ads Error");
    }

    private void OnBannerLoaded()
    {
        Debug.Log("Banner Ads Loaded");
    }

    // Show the loaded content in the Ad Unit:
    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        if (!AdsManager.Instance._isNoAds)
        {
            // Show the loaded Banner Ad Unit:
            Advertisement.Banner.Show(_adUnitId, options);
        }
    }

    private void OnBannerShown()
    {
        
    }

    private void OnBannerHidden()
    {
        
    }

    private void OnBannerClicked()
    {
        
    }

    public void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    #region LoadCallback
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Banner Ads Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {

    }
    #endregion

    #region ShowCallback
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("BannerAd Complete");
    }
    #endregion
}
