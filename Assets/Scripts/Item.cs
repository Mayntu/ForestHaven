using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject {
    
    [Header("Only gameplay")]
    public string itemName;
    [Header("Only UI")]
    public bool stackable = true;
    [Header("Both")]
    public Sprite image;
}
public enum ItemType 
{
    BuildingBlock,
    Tool
}
public enum ActionType 
{
    Dig,
    Mine
}