using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int CoinCount {get; set;}
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private int coinCount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        coinText.text = coinCount.ToString();
    }
    void FixedUpdate() 
    {
        CoinCount = coinCount;
    }
    public void AddCoins(int amount)
    {
        coinCount += amount;
        CoinCount = coinCount;
    }
    public void ReduceCoins(int amount)
    {
        coinCount -= amount;
        CoinCount = coinCount;
    }
}
