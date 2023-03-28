using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthAmount;
    [SerializeField] private float currentHealth;
    [SerializeField] private float healDelay;
    private GameObject enemy;
    [SerializeField] private bool canHeal;
    [SerializeField] private GameObject helpingEnemy;
    private bool isDead = false;
    private bool called;
    private float timeSinceAttack;
    void Start()
    {
        currentHealth = healthAmount;
    }
    void Update()
    {
        CurrentHealth = currentHealth;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            Dead();
            CurrentHealth = currentHealth;
        }

        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     TakeDamage(20);
        // }
        if(enemy == null)
        {
            enemy = helpingEnemy;
        }
        enemyAttack = enemy.GetComponent<EnemyAttack>();
        if(enemyAttack.IsAttacking == false)
        {
            timeSinceAttack += Time.deltaTime;
        }
        else if(enemyAttack.IsAttacking == true)
        {
            timeSinceAttack = 0;
            canHeal = false;
        }

        if(timeSinceAttack >= healDelay)
        {
            canHeal = true;
        }
        AutoHealing();
    }
    EnemyAttack enemyAttack;
    public void TakeDamage(float damage, GameObject enem)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;
        enemy = enem;
        CurrentHealth = currentHealth;
    }
    // IEnumerator DoAutoHeal()
    // {
    //     yield return new WaitForSeconds(healDelay);
    //     canHeal = true;
    // }
    public void AutoHealing()
    {
        if(canHeal == true)
        {
            if(currentHealth < healthAmount)
            {
                healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, 1f, Time.deltaTime * 0.25f);
                currentHealth = Mathf.MoveTowards(currentHealth / healthAmount, 1f, Time.deltaTime * 0.25f) * healthAmount;
                CurrentHealth = currentHealth;
            }
        }
    }
    public void Heal(float healingAmount)
    {
        currentHealth += healingAmount;
        healthBar.fillAmount = currentHealth / 100f;
        CurrentHealth = currentHealth;
    }
    private void Dead()
    {
        if(isDead == true)
        {
            StartCoroutine(DoDeath());
        }
    }
    IEnumerator DoDeath()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
