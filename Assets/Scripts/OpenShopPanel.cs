using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private Animator animator;
    private bool canOpen = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            shopPanel.SetActive(true);
            animator.SetBool("isActive", true);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            animator.SetBool("isActive", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            canOpen = false;
            animator.SetBool("isActive", false);
        }
    }
}
