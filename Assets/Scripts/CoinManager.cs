using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; //singleton for global access

    public TextMeshProUGUI TxtCoin;

    private int totalCoins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount;
        Debug.Log("Coin: " + totalCoins);
        TxtCoin.text = totalCoins.ToString();
    }

    public int GetCoin()
    {
        return totalCoins;
    }

    public void SpendCoin(int amount)
    {
        totalCoins -= amount;
        if (totalCoins < 0)
        {
            totalCoins = 0;
        }
        TxtCoin.text = totalCoins.ToString();
    }
}
