using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Text coinCountText;
    private int coinCount;

    void Awake()
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

    void Start()
    {
        coinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateCoinCountText();
    }

    public void DecreaseCoinCount()
    {
        coinCount--;
        UpdateCoinCountText();
    }

    void UpdateCoinCountText()
    {
        coinCountText.text = "Remaining: " + coinCount;
    }
}