using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyKnockback : MonoBehaviour
{
   	[SerializeField] private float attackRange;
	[SerializeField] private float strength = 16, delay = 0.15f;
    [SerializeField] private Rigidbody2D rb2d;
	[SerializeField] private GameObject sender;
    public UnityEvent OnBegin, OnDone;
    void Start()
    {
		sender = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		
    }
    public void PlayFeedback()
	{
    	StopAllCoroutines();
    	OnBegin?.Invoke();
    	Vector2 direction = (transform.position - sender.transform.position).normalized;
    	rb2d.AddForce(direction * strength, ForceMode2D.Impulse);
    	StartCoroutine(Reset());
	}
	private IEnumerator Reset()
	{
		yield return new WaitForSeconds(delay);
		rb2d.velocity = Vector3.zero;
		OnDone?.Invoke();
	}
}
