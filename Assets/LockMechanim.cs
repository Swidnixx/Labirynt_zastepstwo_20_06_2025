using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public KeyColor properKey;
    public DoorMechanim[] doors;
    Animator animator;

    bool playerInRange;
    bool alreadyOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(alreadyOpen) return; 

        if(Input.GetKeyDown(KeyCode.E) && playerInRange && GameManager.gameManager.HasKey(properKey))
        {
            Open();
            alreadyOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public void Open()
    {
        animator.SetTrigger("open");
        foreach(var d in doors)
        {
            d.open = true;
        }
        GameManager.gameManager.UseKey(properKey);
    }
}
