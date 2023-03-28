using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealth : MonoBehaviour
{
    public bool _isDead {get; set;}
    [SerializeField] private float hp;
    [SerializeField] private GameObject inventoryManager;
    [SerializeField] private Image healthBar, healthBarBorder;
    [SerializeField] private float woodCount;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 0);
    [SerializeField] private GameObject spawner;
    [SerializeField] private bool isGreen, isOrange, isPink;

    private float maxHp;
    private bool isDead;
    private void Awake()
    {
        maxHp = hp;
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager");
        if(isGreen)
        {
            spawner = GameObject.FindGameObjectWithTag("TreeSpawner");
        }
        else if(isOrange)
        {
            spawner = GameObject.FindGameObjectWithTag("OrangeTreeSpawner");
        }
        else if(isPink)
        {
            spawner = GameObject.FindGameObjectWithTag("PinkTreeSpawner");
        }
    }
    private void Update()
    {
        IsDead();
        if(isDead == true)
        {
            Destroy(gameObject);
            for (int i = 0; i < woodCount; i++)
            {
                inventoryManager.GetComponent<DemoScript>().PickupItem(2);
            }
        }
        if(healthBar != null)
        {
            healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
            healthBarBorder.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
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
