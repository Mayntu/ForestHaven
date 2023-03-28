using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private InputActionReference attack, pointerPosition;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private float speedPotionTime;
    private Vector2 moveDirection;
    private Vector2 pointerInput;
    public Vector2 PointerInput => pointerInput;
    public WeaponParent[] weaponParent;
    private Animator animator;
    private float currentSpeed;
    // private bool m_FacingRight = true;
    private void Awake()
    {
        currentSpeed = moveSpeed;
        animator = playerSprite.GetComponent<Animator>();
        weaponParent = GetComponentsInChildren<WeaponParent>();
    }
    private void Update()
    {
        pointerInput = GetPointerInput();
        foreach(WeaponParent _weaponParent in weaponParent)
        {
            _weaponParent.PointerPosition = pointerInput;
        }
        Inputs();
        Flip();
        if(Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void Flip()
    {
        if(moveDirection.x < 0)
        {
            // m_FacingRight = false;
            playerSprite.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if((moveDirection.x > 0))
        {
            // m_FacingRight = true;
            playerSprite.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void PerformAttack()
    {
        foreach(WeaponParent _weaponParent in weaponParent)
        {
            _weaponParent.Attack();
        }
    }
    public void AddSpeed(float speed)
    {
        StartCoroutine(DoSpeed(speed));
    }
    IEnumerator DoSpeed(float newVar)
    {
        moveSpeed = newVar;
        yield return new WaitForSeconds(speedPotionTime);
        moveSpeed = currentSpeed;
    }
}
