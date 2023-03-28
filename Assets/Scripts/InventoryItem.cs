using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Item item;
    [Header("UI")]
    public Image image;
    public Text countText;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;
    WeaponParent weaponParent;
    [SerializeField] private GameObject player;
    void Awake()
    {
        RefreshCount();
    }
    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        countText.raycastTarget = false;
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventData)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponParent = player.GetComponentInChildren<WeaponParent>();
        transform.position = weaponParent.PointerPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        countText.raycastTarget = true;
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
    void Update()
    {
        
    }
}
