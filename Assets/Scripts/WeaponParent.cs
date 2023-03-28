using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public bool IsAttacking { get; private set; }
    [SerializeField] private SpriteRenderer characterRenderer, weaponRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackDelay = 0.3f;
    [SerializeField] private Transform circleOrigin;
    [SerializeField] private float radius;
    [SerializeField] private int damageAmount;
    [SerializeField] private bool damageEnemy;
    [SerializeField] private bool damageTree;
    [SerializeField] private bool damageStone;
    private bool attackBlocked;
    
    private void Update() 
    {
        if(IsAttacking)
        {
            return;
        }
        Vector2 direction = (PointerPosition-(Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if(direction.x < 0)
        {
            scale.y = -1;
        }
        else if(direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }
    public void Attack()
    {
        if(gameObject.activeInHierarchy)
        {
            if(attackBlocked)
            {
                return;
            }
            attackBlocked = true;
            animator.SetBool("isAttacking", true);
            IsAttacking = true;
            StartCoroutine(DelayAttack());
        }
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        attackBlocked = false;
        animator.SetBool("isAttacking", false);
    }
    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectColliders()
    {
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            EnemyHealth health;
            if(health = collider.GetComponent<EnemyHealth>())
            {
                if(damageEnemy == true)
                {
                    health.GetHit(damageAmount, transform.parent.gameObject);
                }
            }
        }
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            TreeHealth treeHealth;
            if(treeHealth = collider.GetComponent<TreeHealth>())
            {
                if(damageTree == true)
                {
                    treeHealth.GetDamage(damageAmount);
                }
            }
        }
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            StoneHealth stoneHealth;
            if(stoneHealth = collider.GetComponent<StoneHealth>())
            {
                if(damageStone == true)
                {
                    stoneHealth.GetDamage(damageAmount);
                }
            }
        }
    }
}
