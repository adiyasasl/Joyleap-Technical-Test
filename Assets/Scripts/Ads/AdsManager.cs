using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    [Header("Components")]
    public InitializeAds _initializeAds;
    public BannerAds _bannerAds;
    public InterstitialAds _interstitialAds;
    public RewardedAds _rewardedAds;

    public bool _isNoAds = false;

    public static AdsManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _bannerAds.LoadBannerAd();
        _interstitialAds.LoadInterstitialAd();
        _rewardedAds.LoadRewardedAd();

        StartCoroutine(ShowBannerAds());
    }

    public void ActivateNoAds()
    {
        _isNoAds = true;
        _bannerAds.HideBannerAd();
    }

    private IEnumerator ShowBannerAds()
    {
        yield return new WaitForSeconds(2f);
        _bannerAds.ShowBannerAd();
    }
}
