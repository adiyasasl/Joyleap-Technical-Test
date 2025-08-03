using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Button _noAdsBtn;

    public static IAPManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void Purchase(Product product)
    {
        if (product.definition.id.Equals("noads"))
        {
            _noAdsBtn.interactable = false;
            AdsManager.Instance.ActivateNoAds();
        }
    }
}
