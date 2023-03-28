using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject machete;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject woodenAxe, goldenAxe, ironAxe, diamondAxe;
    [SerializeField] private GameObject stonePickaxe, goldenPickaxe, ironPickaxe, diamondPickaxe;
    [SerializeField] private float healPotionHeal;
    [SerializeField] private float speedPotionSpeed;
    public int maxStackedItems = 100;
    public int selectedSlot = -1;
    private GameObject player;
    private void Start()
    {
        ChangeSelectedSlot(0);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if(Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number < 10)
            ChangeSelectedSlot(number - 1);
        }
        DetectSelectedItem();
    }
    public void ChangeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
    public bool AddItem(Item item)
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    public Item GetSelectedItem(bool use) 
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null) 
        {
            Item item = itemInSlot.item;
            if(use == true && itemInSlot.item.stackable) 
            {
                itemInSlot.count--;
            }
            if(itemInSlot.count <= 0) 
            {

                Destroy(itemInSlot.gameObject);
            } 
            else 
            {
                itemInSlot.RefreshCount();
                return item;
            }
        }
        return null;
    }
    
    public void DetectSelectedItem()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null) 
        {
            Item item = itemInSlot.item;
            if(itemInSlot.item.itemName == "Knife")
            {
                knife.SetActive(true);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "Machete")
            {
                knife.SetActive(false);
                machete.SetActive(true);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "Sword")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(true);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "WoodenAxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(true);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "GoldenAxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(true);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "IronAxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(true);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "DiamondAxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(true);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "StonePickaxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(true);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "GoldenPickaxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(true);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "IronPickaxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(true);
                diamondPickaxe.SetActive(false);
            }
            else if(itemInSlot.item.itemName == "DiamondPickaxe")
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(true);
            }
            else if(itemInSlot.item == null)
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            else
            {
                knife.SetActive(false);
                machete.SetActive(false);
                sword.SetActive(false);
                woodenAxe.SetActive(false);
                goldenAxe.SetActive(false);
                ironAxe.SetActive(false);
                diamondAxe.SetActive(false);
                stonePickaxe.SetActive(false);
                goldenPickaxe.SetActive(false);
                ironPickaxe.SetActive(false);
                diamondPickaxe.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.F) && itemInSlot.item.itemName == "HealPotion" && player.GetComponent<PlayerHealth>().CurrentHealth <= 80)
            {
                player.GetComponent<PlayerHealth>().Heal(healPotionHeal);
                Destroy(itemInSlot.gameObject);
            }
            else if(Input.GetKeyDown(KeyCode.F) && itemInSlot.item.itemName == "SpeedPotion")
            {
                player.GetComponent<PlayerMovement>().AddSpeed(speedPotionSpeed);
                Destroy(itemInSlot.gameObject);
            }
        }
    }
    public void ConvertWood()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot.item.itemName == "WoodStack" && itemInSlot.count >= 16)
        {
            player.GetComponent<CoinManager>().AddCoins(50);
            itemInSlot.count -= 16;
            itemInSlot.RefreshCount();
        }
    }
    public void ConvertStone()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot.item.itemName == "Stone" && itemInSlot.count >= 10)
        {
            player.GetComponent<CoinManager>().AddCoins(40);
            itemInSlot.count -= 10;
            itemInSlot.RefreshCount();
        }
    }
}
