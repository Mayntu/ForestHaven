using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
	[SerializeField] private float attackRange;
	private Rigidbody2D rb;
    private Transform player;
    private Animator animator;
	private float timeBetweenAttack = 35;
    private float attackCounter;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        	Vector2 target = new Vector2(player.position.x, player.position.y);
			Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
			rb.MovePosition(newPos);
			if(Vector3.Distance(player.position, rb.position) <= attackRange)
			{
				gameObject.GetComponent<EnemyAttack>().Attack();
			}

			attackCounter -= Time.deltaTime;
			if(attackCounter <= 0)
			{
				attackCounter = timeBetweenAttack;
            }
    }
}