using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }
    // public float TimeSinceAttack { get; set;}
    [SerializeField] private GameObject player;
    [SerializeField] private Transform circleOrigin;
    [SerializeField] private float damage;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDelay;
    private bool attackBlocked = false;
    private bool isFlipped = false;
    private float timeSinceAttack;
    // [SerializeField] private bool isAttacking = false;
    PlayerHealth playerHealth;
    Animator animator;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if(IsAttacking)
        {
            return;
        }
        LookAtPlayer();
        // if(isAttacking == false)
        // {
        //     timeSinceAttack += Time.deltaTime;
        //     // Debug.Log(timeSinceAttack);
        //     TimeSinceAttack = timeSinceAttack;
        // }
        // else if(isAttacking == true)
        // {
        //     timeSinceAttack = 0;
        //     TimeSinceAttack = timeSinceAttack;
        // }
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(circleOrigin.position, attackRadius);
    }
    public void Attack()
    {
        if(attackBlocked)
        {
            return;
        }
        Vector3 pos = transform.position;
		Collider2D colInfo = Physics2D.OverlapCircle(circleOrigin.position, attackRadius);
		if (colInfo != null)
		{
			playerHealth.TakeDamage(damage, gameObject);
		}
        attackBlocked = true;
        animator.SetBool("isAttacking", true);
        // isAttacking = true;
        IsAttacking = true;
        StartCoroutine(DelayAttack());
    }
    public void ResetAttack()
    {
        IsAttacking = false;
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        attackBlocked = false;
        animator.SetBool("isAttacking", false);
        // isAttacking = false;
        ResetAttack();
    }
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;
        Transform playerPos = player.transform;
		if (transform.position.x < playerPos.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x > playerPos.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
