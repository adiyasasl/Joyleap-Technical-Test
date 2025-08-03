using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Components")]
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private GameObject _winPanel;

    private int _score = 0;
    private int _clickBtn = 0;
    void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseScore(int value)
    {
        _score += value;
        UpdateScore();
    }

    public void DecreaseScore(int value)
    {
        _score -= value;
        UpdateScore();
    }

    public void AdsDoubleScore()
    {
        AdsManager.Instance._rewardedAds.ShowRewardedAd();
    }

    private void UpdateScore()
    {
        _scoreText.text = _score.ToString();
        _clickBtn++;

        if (_clickBtn == 5)
        {
            AdsManager.Instance._interstitialAds.ShowInterstitialAd();
        }
        else if (_clickBtn == 10)
        {
            _winPanel.SetActive(true);
            _clickBtn = 0;
        }
    }
}
