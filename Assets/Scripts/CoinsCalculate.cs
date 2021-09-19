using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCalculate : MonoBehaviour
{
    [SerializeField] private Text coinsText = null;
    [SerializeField] private Text totalCoins = null;
    private int coins, total;
    private bool finCalculate = false;

    private void Start()
    {
        if (PlayerPrefs.GetString("Total coins").Length > 0)
            totalCoins.text = PlayerPrefs.GetString("Total coins");
        else totalCoins.text = ("Total: 0");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            CoinAdd();
            if (collision.gameObject != null) Destroy(collision.gameObject);
        }
    }

    public void CoinAdd()
    {
        coins++;
        coinsText.text = coins.ToString();
    }

    public void CalculateCoins()
    {
        if (!finCalculate)
        {
            total = System.Convert.ToInt32(totalCoins.text.ToString().
                Substring(7, totalCoins.text.Length - 7)) + coins;
            PlayerPrefs.SetString("Total coins", $"Total: {total}");
            totalCoins.text = PlayerPrefs.GetString("Total coins");
        }
        finCalculate = true;
    }
}
