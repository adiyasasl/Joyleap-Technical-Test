using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private TextMeshProUGUI _coinText;

    [Header("Properties")]
    private int _coinValue;

    public void AddCoin(int value)
    {
        _coinValue += value;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        _coinText.text = _coinValue.ToString();
    }
}
