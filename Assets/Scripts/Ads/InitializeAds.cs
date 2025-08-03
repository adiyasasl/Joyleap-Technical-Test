using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [Header("Properties")]
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    void Awake()
    {
        #if UNITY_IOS
            _gameId = _iOSGameId;
        #elif UNITY_ANDROID
            _gameId = _androidGameId;
        #elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
        #endif
    
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }
    
    public void InitializeUnityAds()
    {
        
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialize Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }
}
