using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;
    void Start()
    {
        PickupItem(3);
    }
    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickUp[id]);
        if(result == true)
        {
            Debug.Log("item added");
        }
        else if(result == false)
        {
            Debug.Log("item not added");
        }
    }
    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if(receivedItem != null)
        {
            Debug.Log("receivedItem" + receivedItem);
        }
        else
        {
            Debug.Log("no item received");
        }
    }
}
