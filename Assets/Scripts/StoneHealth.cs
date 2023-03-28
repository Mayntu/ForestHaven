using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneHealth : MonoBehaviour
{
    public bool _isDead {get; set;}
    [SerializeField] private float hp;
    [SerializeField] private GameObject inventoryManager;
    [SerializeField] private Image healthBar, healthBarBorder;
    [SerializeField] private float stoneCount;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 0);
    [SerializeField] private GameObject spawner;
    [SerializeField] private bool isBlack, isYellow, isRed, isBlue;

    private float maxHp;
    private bool isDead;
    private void Awake()
    {
        maxHp = hp;
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager");
        spawner = GameObject.FindGameObjectWithTag("StoneSpawner");
    }
    private void Update()
    {
        IsDead();
        if(isDead == true)
        {
            Destroy(gameObject);
            for (int i = 0; i < stoneCount; i++)
            {
                inventoryManager.GetComponent<DemoScript>().PickupItem(14);
                SpawnArtifact();
            }
            
        }
        if(healthBar != null)
        {
            healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
            healthBarBorder.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
        }
    }
    public void SpawnArtifact()
    {
        int num = 0;
        if(isBlack)
        {
            var random = new System.Random();
            num = random.Next(1, 20);
            Debug.Log(num);
        }
        else if(isYellow)
        {
            var random = new System.Random();
            num = random.Next(1, 10);
        }
        else if(isRed)
        {
            var random = new System.Random();
            num = random.Next(1, 5);
        }
        else if(isBlue)
        {
            var random = new System.Random();
            num = random.Next(1, 4);
        }
        if(num == 1)
        {
            inventoryManager.GetComponent<DemoScript>().PickupItem(15);
        }
    }
    public void GetDamage(float damage)
    {
        hp -= damage;
        healthBar.fillAmount = hp / maxHp;
    }
    public void IsDead()
    {
        if(hp <= 0)
        {
            isDead = true;
            spawner.GetComponent<TreeSpawner>().CutDownTree();
        }
    }
    IEnumerator DoDeath()
    {
        yield return new WaitForSeconds(1f);
    }
}
