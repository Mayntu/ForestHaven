using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuyingSystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryManager;
    [SerializeField] private int knifePrice;
    [SerializeField] private int machetePrice;
    [SerializeField] private int swordPrice;
    [SerializeField] private int woodenAxePrice, goldenAxePrice, ironAxePrice, diamondAxePrice;
    [SerializeField] private int stonePickaxePrice, goldenPickaxePrice, ironPickaxePrice, diamondPickaxePrice;
    [SerializeField] private int healPotionPrice, speedPotionPrice;
    [SerializeField] private int healPotionArtifactPrice, speedPotionArtifactPrice;
    void Start()
    {
    }
    void Update()
    {
        
    }
    public void BuyKnife()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= knifePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(knifePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(3);
        }
    }
    public void BuyMachete()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= machetePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(machetePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(4);
        }
    }
    public void BuySword()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= swordPrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(swordPrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(5);
        }
    }
    public void BuyWoodenAxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= woodenAxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(woodenAxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(6);
        }
    }
    public void BuyGoldenAxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= goldenAxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(goldenAxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(7);
        }
    }
    public void BuyIronAxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= ironAxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(ironAxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(8);
        }
    }

    public void BuyDiamondAxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= diamondAxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(diamondAxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(9);
        }
    }
    public void BuyStonePickaxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= stonePickaxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(stonePickaxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(10);
        }
    }
    public void BuyGoldenPickaxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= goldenPickaxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(goldenPickaxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(11);
        }
    }
    public void BuyIronPickaxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= ironPickaxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(ironPickaxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(12);
        }
    }
    public void BuyDiamondPickaxe()
    {
        if(gameObject.GetComponent<CoinManager>().CoinCount >= diamondPickaxePrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(diamondPickaxePrice);
            inventoryManager.GetComponent<DemoScript>().PickupItem(13);
        }
    }
    public void BuyHealPotion()
    {
        InventorySlot slot = inventoryManager.GetComponent<InventoryManager>().inventorySlots[inventoryManager.GetComponent<InventoryManager>().selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(gameObject.GetComponent<CoinManager>().CoinCount >= healPotionPrice && itemInSlot.item.itemName == "Artifact" && itemInSlot.count >= healPotionArtifactPrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(healPotionPrice);
            itemInSlot.count -= healPotionArtifactPrice;
            itemInSlot.RefreshCount();
            inventoryManager.GetComponent<DemoScript>().PickupItem(16);
        }
    }
    public void BuySpeedPotion()
    {
        InventorySlot slot = inventoryManager.GetComponent<InventoryManager>().inventorySlots[inventoryManager.GetComponent<InventoryManager>().selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(gameObject.GetComponent<CoinManager>().CoinCount >=speedPotionPrice && itemInSlot.item.itemName == "Artifact" && itemInSlot.count >= speedPotionArtifactPrice)
        {
            gameObject.GetComponent<CoinManager>().ReduceCoins(speedPotionPrice);
            itemInSlot.count -= speedPotionArtifactPrice;
            itemInSlot.RefreshCount();
            inventoryManager.GetComponent<DemoScript>().PickupItem(17);
        }
    }
}
