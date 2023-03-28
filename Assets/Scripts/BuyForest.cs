using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyForest : MonoBehaviour
{
    [SerializeField] private GameObject placeToBuy;
    [SerializeField] private GameObject buyPanel;
    [SerializeField] private int placeCost;
    private bool canOpen;
    void Start()
    {
        
    }
    void Update()
    {
        if(buyPanel != null)
        {
            buyPanel.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            if(canOpen == true) if(Input.GetKeyDown(KeyCode.E)) buyPanel.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Escape)) buyPanel.SetActive(false);
        }
    }
    public void BuyPlace()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<CoinManager>().CoinCount >= placeCost)
        {
            Destroy(placeToBuy);
            Destroy(buyPanel);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CoinManager>().ReduceCoins(placeCost);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            canOpen = false;
            if(buyPanel != null)
            {
                buyPanel.SetActive(false);
            }
        }
    }
}
